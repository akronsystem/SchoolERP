using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI;
using SchoolAPI.Param;
using SchoolAPI.Models;
using SchoolAPI.ResultModel;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using New_project.Models;

namespace SchoolAPI.BusinessLayer
{
    
    public class SchoolBusiness
    {
        SchoolERPContext db = new SchoolERPContext();
        public object SaveSchool(School s)
        {
            try
            {
                var Logo = System.Web.HttpContext.Current.Request.Files["file"];
                var Banner = System.Web.HttpContext.Current.Request.Files["file1"];
                var json1 = System.Web.HttpContext.Current.Request.Form["id"];
                var json = System.Web.HttpContext.Current.Request.Form["data"];
                School school = Newtonsoft.Json.JsonConvert.DeserializeObject<School>(json);
                //var boardid = json1.Replace(",", "");
               
                    if (school.UserName == null)
                {
                    return new Error() { IsError = true, Message = "Required Username" };
                }
                var info = db.TblSchools.Where(r => r.SchoolName == school.SchoolName).FirstOrDefault();
                if (info != null)
                {
                    return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
                }
                TblSchool obj = new TblSchool();
                var httpRequest = HttpContext.Current.Request;
                string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                string fileLogo = string.Empty;
                string fileBanner = string.Empty;
                var filePath = string.Empty;
                string savePath = string.Empty;
                var filePathBanner = string.Empty;
                var filePathSave = string.Empty;
                var Upload = school.SchoolName;

                obj.SchoolName = school.SchoolName;
                obj.PhoneNo = school.PhoneNo;
                obj.Address = school.Address;
                obj.ContactPerson = school.ContactPerson;
                obj.LandlineNo = school.LandlineNo;
                obj.EmailId = school.EmailId;
                obj.Designation = school.Designation;
                obj.ValidityStartDate = school.ValidityStartDate;
                obj.ValidityEndDate = school.ValidityEndDate;
                obj.PayrollTemplateId = school.PayrollTemplateId;
                obj.FeeTemplateId = school.FeeTemplateId;
                obj.LoginTemplateId = school.LoginTemplateId;
                obj.ExamTemplateId = school.ExamTemplateId;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = 1;
                obj.ModifiedDate = System.DateTime.Today.Date;
                obj.UserPrefix = school.UserPrefix;
                obj.UserName = school.UserName;
                obj.Password = school.Password;                
                obj.Language = school.Language;
                obj.Status = 1;

                var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "SchoolUpload" + ("\\"));
                if (!Directory.Exists(uploaddirc))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                }
                string paths = "SchoolUpload";
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var uploadpath = Path.Combine(HttpContext.Current.Server.MapPath("/"), paths, Upload.ToString() + ("\\"));
                    if (!Directory.Exists(uploadpath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(uploadpath);
                    }
                    if (i == 0 && Logo != null)
                    {
                        var file = httpRequest.Files[i];
                        var Guids = Guid.NewGuid();
                        filePathSave = uploadpath + Guids;
                        filePath = filePathSave + file.FileName;

                        savePath = uploadpath;
                        file.SaveAs(filePath);
                        obj.Logo = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
                        //string Logo1 = data.Logo.Replace("~/", "");
                        //data.Logo = Logo1;
                    }
                    else
                    {
                        var file = httpRequest.Files[i];
                        var GuidsBanner = Guid.NewGuid();
                        filePathSave = uploadpath + GuidsBanner;
                        filePathBanner = filePathSave + file.FileName;

                        savePath = uploadpath;
                        file.SaveAs(filePathBanner);
                        obj.Banner = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                        //string Banner1 = data.Banner.Replace("~/", "");
                        //data.Banner = Banner1;
                    } 


                }

                 db.TblSchools.Add(obj);
                db.SaveChanges();
                CopyDB objDB = new CopyDB();
                string name = school.SchoolName.Replace(" ", "") + "DB";
                objDB.Copydata(name.ToUpper());
                var details= db.TblSchools.FirstOrDefault(r => r.SchoolName == school.SchoolName);
                TblBoardDetail board = new TblBoardDetail();
                string[] ids = json1.Split(',');

                for (int i = 0; i < ids.Length; i++)
                {
                    board.SchoolId = details.SchoolId;
                    board.BoardId =Convert.ToInt64(ids[i].Replace("[","").Replace("]",""));
                    board.CreatedBy = 1;
                    board.CreatedDate = System.DateTime.Today.Date;
                    board.ModifiedBy = null;
                    board.ModifiedDate = System.DateTime.Today.Date;
                    db.TblBoardDetails.Add(board);
                    db.SaveChanges();
                }


                //user.code = Convert.ToInt32(HttpContext.Current.Session["Code"]);
                return new Result
                {
                    IsSucess = true,
                    ResultData = "School Created!"
                };
            }
            catch(Exception e)
            {
                return new Error { IsError = true, Message = e.Message };
            }



        }
        public object GetSchoolInfo(GetSchool obj)
        {
            //var data = db.TblSchools.Where(r => r.UserName == obj.UserName && r.Password == obj.Password).FirstOrDefault();
            //if(data==null)
            //{
            //    return new Error() { IsError = true, Message = "Please Check UserName or Password" };
            //}
            try
            {
                var schoolid = db.View_SchoolDetails.Where(r => r.SchoolId == obj.SchoolId).FirstOrDefault();
                if (schoolid == null)
                {
                    return new Error() { IsError = true, Message = "School  Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = schoolid };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }

        public object UpdateSchoolInfo(UpdateSchool school)
        {
            var httpRequest = HttpContext.Current.Request;
            var Logo = System.Web.HttpContext.Current.Request.Files["logo"];
 
            var Banner = System.Web.HttpContext.Current.Request.Files["banner"];
            var json1 = System.Web.HttpContext.Current.Request.Form["id"];
            var json = System.Web.HttpContext.Current.Request.Form["data"];
            UpdateSchool info = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateSchool>(json);
            if (info.SchoolName == null)
            {
                return new Error() { IsError = true, Message = "Requird Name" };
            }
            //var datas = db.TblSchools.FirstOrDefault(r => r.SchoolName == info.SchoolName);
            //if (Logo != null)
            //{
            //    return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            //}
            var data = db.TblSchools.Where(r => r.SchoolId == info.SchoolId).FirstOrDefault();

            TblSchool obj = new TblSchool();
            string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
            string fileLogo = string.Empty;
            string fileBanner = string.Empty;
            var filePath = string.Empty;
            var filePathBanner = string.Empty;
            var filePathSave = string.Empty;
            string savePath = string.Empty;
            var Upload = data.SchoolName;
           

            data.SchoolId = info.SchoolId;
            data.SchoolName = info.SchoolName;
            data.PhoneNo = info.PhoneNo;
            data.Address = info.Address;
            data.ContactPerson = info.ContactPerson;
            data.PayrollTemplateId = info.PayrollTemplateId;
            data.FeeTemplateId = info.FeeTemplateId;
            data.LoginTemplateId = info.LoginTemplateId;
            data.ExamTemplateId = info.ExamTemplateId;
            data.ModifiedBy = 1;
            data.ModifiedDate = System.DateTime.Today.Date;
            data.UserPrefix = info.UserPrefix;
            data.UserName = info.UserName;
            data.Password = info.Password;           
            data.Language = info.Language;
            data.LandlineNo = info.LandlineNo;
            data.EmailId = info.EmailId; 
             data.Designation = info.Designation;          
              data.CreatedBy = data.CreatedBy;
              data.CreatedDate = data.CreatedDate;

            TblBoardDetail board = new TblBoardDetail();
            string[] ids = json1.Split(',');
            var boarddata= db.TblBoardDetails.Where(r => r.SchoolId == info.SchoolId).FirstOrDefault();
            //var getinfo = db.TblBoardDetails.Where(r => r.SchoolId == info.SchoolId && r.BoardId==boarddata.BoardId).FirstOrDefault();
            if(boarddata==null)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    board.SchoolId = data.SchoolId;

                    board.BoardId = Convert.ToInt64(ids[i].Replace("[", "").Replace("]", ""));
                    board.CreatedBy = 1;
                    board.CreatedDate = System.DateTime.Today.Date;
                    board.ModifiedBy = null;
                    board.ModifiedDate = System.DateTime.Today.Date;

                    db.TblBoardDetails.Add(board);
                    db.SaveChanges();
                }
            }
            else
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    board.SchoolId = boarddata.SchoolId;

                    board.BoardId = Convert.ToInt64(ids[i].Replace("[", "").Replace("]", ""));
                    board.CreatedBy = 1;
                    board.CreatedDate = System.DateTime.Today.Date;
                    board.ModifiedBy = null;
                    board.ModifiedDate = System.DateTime.Today.Date;

                    //db.TblBoardDetails.Add(board);
                    db.SaveChanges();
                }
            }
           
            if (httpRequest.Files.Count == 0) 
            {
                db.SaveChanges();
                return new Result
                {

                    IsSucess = true,
                    ResultData = "School Updated!"
                };
            }
            else
            {
                var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "SchoolUpload" + ("\\"));
                if (!Directory.Exists(uploaddirc))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                }
                string paths = "SchoolUpload";
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var uploadpath = Path.Combine(HttpContext.Current.Server.MapPath("/"),paths,Upload.ToString()+("\\"));
                    if (!Directory.Exists(uploadpath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(uploadpath);
                    }
                    if (i == 0 && Logo!=null)
                    {                        
                        var file = httpRequest.Files[i];
                        var Guids=Guid.NewGuid();
                        filePathSave = uploadpath + Guids;
                        filePath = filePathSave + file.FileName;

                        savePath = uploadpath;
                        file.SaveAs(filePath);
                        data.Logo = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
                        //string Logo1 = data.Logo.Replace("~/", "");
                        //data.Logo = Logo1;
                    }
                    else
                    {
                        var file = httpRequest.Files[i];
                        var GuidsBanner= Guid.NewGuid();
                        filePathSave = uploadpath + GuidsBanner;
                        filePathBanner = filePathSave + file.FileName;

                        savePath = uploadpath;
                        file.SaveAs(filePathBanner);
                        data.Banner = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                        //string Banner1 = data.Banner.Replace("~/", "");
                        //data.Banner = Banner1;
                    }



                }             
              
                db.SaveChanges();
                return new Result
                {
                    IsSucess = true,
                    ResultData = "School Updated!"
                };
            }



        }
        public object GetSchool(ActiveParam s)
        {
            try
            {
                //List<ViewSchoolLists> StudentData = null;
                List<View_SchoolDetails> StudentData = null;
                if (s.Status == "Deactive")
                {
                    StudentData = db.View_SchoolDetails.Where(r => r.Status == 0).ToList();
                }
                else
                {
                    StudentData = db.View_SchoolDetails.Where(r => r.Status == 1).ToList();
                    
                }

                if (StudentData == null)
                {
                    return new Error { IsError = true, Message = "School List Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = StudentData };
                }
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        
        public object GetFeeTemplate()
        {
            try
            {
                var tem = db.View_Template.Where(r => r.TemplateType == "FEE TEMPLATE").ToList();
                return new Result() { IsSucess = true, ResultData = tem };
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
           

        }
        public object GetPayrollTemplate()
        {
            try
            {
                var tem1 = db.View_Template.Where(r => r.TemplateType == "PAYROLL TEMPLATE").ToList();
                return new Result() { IsSucess = true, ResultData = tem1 };
            }
           catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetLoginTemplate()
        {
            try
            {
                var tem2 = db.View_Template.Where(r => r.TemplateType == "LOGIN TEMPLATE").ToList();
                return new Result() { IsSucess = true, ResultData = tem2 };
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }


        }
        public object GetExamTemplate()
        {
            try
            {
                var tem2 = db.View_Template.Where(r => r.TemplateType == "EXAM TEMPLATE").ToList();
                return new Result() { IsSucess = true, ResultData = tem2 };

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        public object Delete(UpdateSchool s)
        {
            try
            {
                TblSchool objuser = db.TblSchools.Where(r => r.SchoolId == s.SchoolId).FirstOrDefault();
                if (objuser.Status == 1)
                {
                    objuser.Status = 0;
                }
                else
                {
                    objuser.Status = 1;
                }
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Deactivted" };

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
        public object SaveBoard(BoardParam b)
        {
            if(b.BoardName==null)
            {
                return new Error() { IsError = true, Message = "Required BoardName" };
            }
            var data = db.TblBoards.Where(r => r.BoardName == b.BoardName).FirstOrDefault();
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                TblBoard obj = new TblBoard();
                obj.BoardName = b.BoardName;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate= System.DateTime.Today.Date;
                db.TblBoards.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Board" };
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
          
        }
        public object BoardUpdate(BoardParam b)
        {
            if (b.BoardName == null)
            {
                return new Error() { IsError = true, Message = "Required BoardName" };
            }
            var data = db.TblBoards.Where(r => r.BoardId == b.BoardId).FirstOrDefault();
            try
            {
                TblBoard obj = new TblBoard();
                data.BoardName = b.BoardName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Board" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetBoard(UserCredential obj)
        {
            try
            {
                List<TblBoard> board = null;

                if (obj.Status == "0")
                {
                    board = db.TblBoards.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    board = db.TblBoards.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    board = db.TblBoards.Where(r => r.Status == 1).ToList();

                }

                if (board == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return board;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
         

        }
        public object GetSingleBoard(BoardParam b)
        {
            try
            {
                var board = db.TblBoards.Where(r=>r.BoardId==b.BoardId).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = board };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }

        public object SaveLanguage(LanguageParam b)
        {
            if (b.Language == null)
            {
                return new Error() { IsError = true, Message = "Required Language" };
            }
            var data = db.TblLanguages.Where(r => r.Language == b.Language).FirstOrDefault();
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                TblLanguage obj = new TblLanguage();
                obj.Language = b.Language;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.TblLanguages.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Language" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteBoard(BoardParam PM)
        {
            try
            {
                TblBoard obj= db.TblBoards.Where(r => r.BoardId == PM.BoardId).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Board Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        //language
        public object GetLanguage(UserCredential obj)
        {
            try
            {
                List<TblLanguage> language = null;

                if (obj.Status == "0")
                {
                    language = db.TblLanguages.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    language = db.TblLanguages.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    language = db.TblLanguages.Where(r => r.Status == 1).ToList();

                }

                if (language == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return language;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleLanguage(LanguageParam b)
        {
            try
            {
                var language = db.TblLanguages.Where(r => r.LanguageId == b.LanguageId).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = language };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object LanguageUpdate(LanguageParam b)
        {
            if (b.Language == null)
            {
                return new Error() { IsError = true, Message = "Required Language" };
            }
            var data = db.TblLanguages.Where(r => r.LanguageId == b.LanguageId).FirstOrDefault();
            try
            {
                TblBoard obj = new TblBoard();
                data.Language = b.Language;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Language" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteLanguage(LanguageParam PM)
        {
            try
            {


                TblLanguage obj = db.TblLanguages.Where(r => r.LanguageId == PM.LanguageId).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Language Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }


    }
}
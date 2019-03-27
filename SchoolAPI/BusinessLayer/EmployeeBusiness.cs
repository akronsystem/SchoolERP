using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class EmployeeBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveEmployee(EmployeeMasterParam s)
        {
            var Profile = System.Web.HttpContext.Current.Request.Files["ImagePath"];
            var Sign = System.Web.HttpContext.Current.Request.Files["Sign"];
            var json = System.Web.HttpContext.Current.Request.Form["data"];
            EmployeeMasterParam b = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeMasterParam>(json);
            if (b.DepartmentID == 0)
            {
                return new Error() { IsError = true, Message = "Required Employee Type" };
            }
            var data = db.Tbl_EmployeeMaster.FirstOrDefault(r => r.MobileNo == b.MobileNo);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_EmployeeMaster obj = new Tbl_EmployeeMaster();
                var httpRequest = HttpContext.Current.Request;
                string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                string fileLogo = string.Empty;
                string fileBanner = string.Empty;
                var filePath = string.Empty;
                string savePath = string.Empty;
                var filePathBanner = string.Empty;
                var filePathSave = string.Empty;
                var Upload = b.EmployeeName;

                obj.EmployeeCode = b.EmployeeCode;
                obj.EmployeeName = b.EmployeeName;
                obj.DepartmentID = b.DepartmentID;
                obj.DesignationID = b.DesignationID;
                obj.SectionID = b.SectionID;
                obj.MobileNo = b.MobileNo;
                obj.AlternateMobileNo = b.AlternateMobileNo;
                obj.Gender = b.Gender;
                obj.EmailID = b.EmailID;
                obj.AlternateEmailID = b.AlternateEmailID;
                obj.BloodGroup = b.BloodGroup;
                obj.ReligionID = b.ReligionID;
                obj.CategoryID = b.CategoryID;
                obj.CasteID = b.CasteID;
                obj.SubCasteID = b.SubCasteID;
                obj.DateofBirth = b.DateofBirth;
                obj.ShiftID = b.ShiftID;  
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = 1;
                obj.ModifiedDate = System.DateTime.Today.Date;

                var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "EmployeeUpload" + ("\\"));
                if (!Directory.Exists(uploaddirc))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                }
                string paths = "EmployeeUpload";
                for (int i = 0; i < httpRequest.Files.Count; i++)
                {
                    var uploadpath = Path.Combine(HttpContext.Current.Server.MapPath("/"), paths, Upload.ToString() + ("\\"));
                    if (!Directory.Exists(uploadpath))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(uploadpath);
                    }
                    if (i == 0 && Profile != null)
                    {
                        var file = httpRequest.Files[i];
                        var Guids = Guid.NewGuid();
                        filePathSave = uploadpath + Guids;
                        filePath = filePathSave + file.FileName;

                        savePath = uploadpath;
                        file.SaveAs(filePath);
                        obj.ImagePath = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
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
                        obj.Sign = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                        //string Banner1 = data.Banner.Replace("~/", "");
                        //data.Banner = Banner1;
                    }


                }
                db.Tbl_EmployeeMaster.Add(obj);
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SaveEmployeeAddress(EmployeeAddressParam b)
        {            
             try
             {
                var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();

                //save AddressDetails
                Tbl_EmployeeAddressDetails objadd = new Tbl_EmployeeAddressDetails();
                objadd.EmployeeID = Info.EmployeeID;
                objadd.PermanentAddress = b.PermanentAddress;
                objadd.PermanantStateID = b.PermanantStateID;
                objadd.PermanantDistrictID = b.PermanantDistrictID;
                objadd.PermanantTalukaID = b.PermanantTalukaID;
                objadd.PermanantPincode = b.PermanantPincode;
                objadd.PermanentCountry = b.PermanentCountry;
                objadd.CorrespondanceAddress = b.CorrespondanceAddress;
                objadd.CorrespondanceStateID = b.CorrespondanceStateID;
                objadd.CorrespondanceDistrictID = b.CorrespondanceDistrictID;
                objadd.CorrespondanceTalukaID = b.CorrespondanceTalukaID;
                objadd.CorrespondancePincode = b.CorrespondancePincode;
                objadd.CorrespondanceCountry = b.CorrespondanceCountry;
                objadd.CreatedBy = null;
                objadd.CreatedDate = System.DateTime.Today.Date;
                objadd.ModifiedBy = null;
                objadd.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_EmployeeAddressDetails.Add(objadd);
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SaveEmployeeBank(EmployeeBankParam b)
        {
           
            try
            {
                var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();

                //Save Bank Details
                Tbl_EmployeeBankDetails objbank = new Tbl_EmployeeBankDetails();
                objbank.EmployeeID = Info.EmployeeID;
                objbank.BankName = b.BankName;
                objbank.AccountNumber = b.AccountNumber;
                objbank.BranchName = b.BranchName;
                objbank.IFSCCode = b.IFSCCode;
                objbank.MICRCode = b.MICRCode;
                objbank.UAN = b.UAN;
                objbank.PF = b.PF;
                objbank.CreatedBy = null;
                objbank.CreatedDate = System.DateTime.Today.Date;
                objbank.ModifiedBy = null;
                objbank.ModifiedDate = System.DateTime.Today.Date;
                objbank.Status = 1;
                db.Tbl_EmployeeBankDetails.Add(objbank);
                db.SaveChanges();
                
                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SaveEmployeeAppointment(EmployeeAppointmentParam b)
        {
            try
            {
                var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();

                 //Save AppointmentDetails
                Tbl_EmployeeAppointmentDetails objapp = new Tbl_EmployeeAppointmentDetails();
                objapp.EmployeeID = Info.EmployeeID;
                objapp.AppointmentType = b.AppointmentType;
                objapp.JobType = b.JobType;
                objapp.JoiningDate = b.JoiningDate;
                objapp.SrGradeScaleApplicable = b.SrGradeScaleApplicable;
                objapp.SrGradeScaleApplicableDate = b.SrGradeScaleApplicableDate;
                objapp.SelectionGradeScaleApplicable = b.SelectionGradeScaleApplicable;
                objapp.SelectionGradeScaleApplicableDate = b.SelectionGradeScaleApplicableDate;
                objapp.CreatedBy = null;
                objapp.CreatedDate = System.DateTime.Today.Date;
                objapp.ModifiedBy = null;
                objapp.ModifiedDate = System.DateTime.Today.Date;
                objapp.Status = 1;
                db.Tbl_EmployeeAppointmentDetails.Add(objapp);
                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SaveEmployeeEducation(List<EmployeeEducationParam> b)
        {
            try
            {
                var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();

                //Save Education Details
                Tbl_EmployeeEducationDetails objedu = new Tbl_EmployeeEducationDetails();
                for(int i=0; i<b.Count; i++)
                {
                    objedu.EmployeeID = Info.EmployeeID;
                    objedu.CourseName = b[i].CourseName;
                    objedu.PassingMothYear = b[i].PassingMothYear;
                    objedu.SchoolCollege = b[i].SchoolCollege;
                    objedu.UniversityBoard = b[i].UniversityBoard;
                    objedu.BoardDivisionState = b[i].BoardDivisionState;
                    objedu.CreditPercentageSGPA = b[i].CreditPercentageSGPA;
                    objedu.CreatedBy = null;
                    objedu.CreatedDate = System.DateTime.Today.Date;
                    objedu.ModifiedBy = null;
                    objedu.ModifiedDate = System.DateTime.Today.Date;
                    objedu.Status = 1;
                    db.Tbl_EmployeeEducationDetails.Add(objedu);
                    db.SaveChanges();
                }
                          
                

                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SaveUploadDocuments(EmployeeAttachedDocumentParam b)
        {
            var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();
            if(Info==null)
            {
                return new Error() { IsError = true, Message = "Required Employee ID" };
            }
            Tbl_EmployeeAttachedDocuments obj = new Tbl_EmployeeAttachedDocuments();
            var json = System.Web.HttpContext.Current.Request.Form["UploadName"];
            var Banner = System.Web.HttpContext.Current.Request.Form["file1"];
            //var data = json.Replace(",$$hashKey:object:94", "");
            //EmployeeAttachedDocumentParam doc = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeAttachedDocumentParam>(json);
           
            //obj.DocumentType = json.Split(,)
            string[] DocType = json.Split(',');
            string[] FileName = Banner.Split(',');
            for(int i=0;i<DocType.Length;i++)
            {
                obj.EmployeeID = Info.EmployeeID;
                obj.DocumentType = DocType[i].ToString();
                obj.Path = FileName[i].ToString();
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Now;
                obj.ModifiedBy = 1;
                obj.ModifiedDate = System.DateTime.Now;
                obj.Status = 1;
                db.Tbl_EmployeeAttachedDocuments.Add(obj);
                db.SaveChanges();
            }


            return null;
        }
        public object SaveExperienceEducation(List<EmployeeExprienceParam> b)
        {
            try
            {
                var Info = db.Tbl_EmployeeMaster.OrderByDescending(r => r.EmployeeID).FirstOrDefault();

                //Save Education Details
                Tbl_EmployeeExprienceDetails objedu = new Tbl_EmployeeExprienceDetails();
                for (int i = 0; i < b.Count; i++)
                {
                    objedu.EmployeeID = Info.EmployeeID;
                    objedu.ExprienceTypeID = b[i].ExprienceTypeID;
                    objedu.ExperienceDocumentType = b[i].ExperienceDocumentType;
                    objedu.Organization = b[i].Organization;
                    objedu.OrganizationAddress = b[i].OrganizationAddress;
                    objedu.Designation = b[i].Designation;
                    objedu.PeriodFrom = b[i].PeriodFrom;
                    objedu.PeriodTo = b[i].PeriodTo;
                    objedu.TotalExprience = b[i].TotalExprience;

                    objedu.CreatedBy = null;
                    objedu.CreatedDate = System.DateTime.Today.Date;
                    objedu.ModifiedBy = null;
                    objedu.ModifiedDate = System.DateTime.Today.Date;
                    objedu.Status = 1;
                    db.Tbl_EmployeeExprienceDetails.Add(objedu);
                    db.SaveChanges();
                }



                return new Result() { IsSucess = true, ResultData = "Created Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetDepartmentList(UserCredential u)
        {
            try
            {
                List<ViewDepartmentList> GetDepartment = null;

                if (u.Status == "0")
                {
                    GetDepartment = db.ViewDepartmentLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetDepartment = db.ViewDepartmentLists.Where(r => r.Status == 1).ToList();

                }

                if (GetDepartment == null)
                {
                    return new Error { IsError = true, Message = "Department Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetDepartment };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetSectionList(UserCredential u)
        {
            try
            {
                List<View_SectionDisplay> section = null;

                if (u.Status == "0")
                {
                    section = db.View_SectionDisplay.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    section = db.View_SectionDisplay.Where(r => r.Status == 1).ToList();

                }

                if (section == null)
                {
                    return new Error { IsError = true, Message = "Department Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = section };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetStateunderTaluka(TalukaParam p)
        {
            try
            {
                var data = db.ViewTalukaLists.Where(r => r.Status == 1 && r.StateID == p.StateId ).ToList();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return data;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetDesignationList(UserCredential s)
        {
            try
            {
                List<ViewDesignationList> GetDesignation = null;

                if (s.Status == "0")
                {
                    GetDesignation = db.ViewDesignationLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetDesignation = db.ViewDesignationLists.Where(r => r.Status == 1).ToList();

                }

                if (GetDesignation == null)
                {
                    return new Error { IsError = true, Message = "Designation Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetDesignation };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetTaluka(TalukaParam p)
        {
            try
            {
                var data = db.ViewTalukaLists.Where(r => r.Status == 1 && r.StateID == p.StateId && r.DistrictID==p.DistrictID).ToList();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return data;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetCategoryList(CasteParam objid)
        {
            try
            {
                List<ViewCasteList> GetCategory = null;

                if (objid.Status == 0)
                {
                    GetCategory = db.ViewCasteLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetCategory = db.ViewCasteLists.Where(r => r.Status == 1).ToList();

                }

                if (GetCategory == null)
                {
                    return new Error { IsError = true, Message = "Category Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetCategory };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetReligionList(CasteParam objid)
        {
            try
            {
                List<ViewCategoryReligionCaste> GetCategory = null;

                if (objid.Status == 0)
                {
                    GetCategory = db.ViewCategoryReligionCastes.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetCategory = db.ViewCategoryReligionCastes.Where(r => r.Status == 1 && r.CasteID==objid.CasteID).ToList();

                }

                if (GetCategory == null)
                {
                    return new Error { IsError = true, Message = "Category Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetCategory };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetEmployee(UserCredential obj)
        {
            try
            {
                List<ViewEmployeeMasterList> Employee = null;

                if (obj.Status == "Deactive")
                {
                    Employee = db.ViewEmployeeMasterLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Employee = db.ViewEmployeeMasterLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Employee = db.ViewEmployeeMasterLists.Where(r => r.Status == 1).ToList();

                }

                if (Employee == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Employee;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetEmployeeInfo(EmployeeMasterParam obj)
        {
           
            try
            {
                var schoolid = db.ViewEmployeeMasterLists.Where(r => r.EmployeeCode == obj.EmployeeCode).FirstOrDefault();
                if (schoolid == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
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
        public object GetEmployeeExperience(EmployeeMasterParam obj)
        {

            try
            {
                var schoolid = db.ViewEmployeeExperienceLists.Where(r => r.EmployeeCode == obj.EmployeeCode).ToList();
                if (schoolid == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
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
        public object GetEmployeeEducation(EmployeeMasterParam obj)
        {

            try
            {
                List<ViewEmployeeEducationList> Data = null;
                Data = db.ViewEmployeeEducationLists.Where(r => r.EmployeeCode == obj.EmployeeCode).ToList();
                if (Data == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Data };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object GetEmployeeDocument(EmployeeMasterParam obj)
        {

            try
            {
                var schoolid = db.ViewEmployeeDocumentDetails.Where(r => r.EmployeeCode == obj.EmployeeCode).ToList();
                if (schoolid == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
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
        public object GetEmployeeDocumentUpdate(EmployeeAttachedDocumentUpdate obj)
        {

            try
            {
                var data = db.Tbl_EmployeeAttachedDocuments.Where(r => r.EmployeeID == obj.EmployeeID &&r.AttachmentID==obj.AttachmentID).First();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
                }
                
                Tbl_EmployeeAttachedDocuments d = new Tbl_EmployeeAttachedDocuments();
                data.Status = 0;
                db.SaveChanges();
                return new Result
                {

                    IsSucess = true,
                    ResultData = "Employee Details Updated!"
                };
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object GetEmployeeEducationsUpdate(EmployeeEducationUpdate obj)
        {

            try
            {
                var data = db.Tbl_EmployeeEducationDetails.Where(r => r.EmployeeID == obj.EmployeeID && r.EducationID == obj.EducationID).First();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
                }

                Tbl_EmployeeAttachedDocuments d = new Tbl_EmployeeAttachedDocuments();
                data.Status = 0;
                db.SaveChanges();
                return new Result
                {

                    IsSucess = true,
                    ResultData = "Employee Details Updated!"
                };
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateEmployee(EmployeeMasterParam s)
        {
            var Profile = System.Web.HttpContext.Current.Request.Files["ImagePath"];
            var Sign = System.Web.HttpContext.Current.Request.Files["Sign"];
            var json = System.Web.HttpContext.Current.Request.Form["data"];
            EmployeeMasterParam b = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeeMasterParam>(json);
            if (b.DepartmentID == 0)
            {
                return new Error() { IsError = true, Message = "Required Employee Type" };
            }
            var data = db.Tbl_EmployeeMaster.Where(r => r.EmployeeCode == b.EmployeeCode).FirstOrDefault();
            //if (data != null)
            //{
             //   return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            //}
            try
            {
                Tbl_EmployeeMaster obj = new Tbl_EmployeeMaster();
                var httpRequest = HttpContext.Current.Request;
                string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                string fileLogo = string.Empty;
                string fileBanner = string.Empty;
                var filePath = string.Empty;
                string savePath = string.Empty;
                var filePathBanner = string.Empty;
                var filePathSave = string.Empty;
                var Upload = b.EmployeeName;

                data.EmployeeCode = b.EmployeeCode;
                data.EmployeeName = b.EmployeeName;
                data.DepartmentID = b.DepartmentID;
                data.DesignationID = b.DesignationID;
                data.SectionID = b.SectionID;
                data.MobileNo = b.MobileNo;
                data.AlternateMobileNo = b.AlternateMobileNo;
                data.Gender = b.Gender;
                data.EmailID = b.EmailID;
                data.AlternateEmailID = b.AlternateEmailID;
                data.BloodGroup = b.BloodGroup;
                data.ReligionID = b.ReligionID;
                data.CategoryID = b.CategoryID;
                data.CasteID = b.CasteID;
                data.SubCasteID = b.SubCasteID;
                data.DateofBirth = b.DateofBirth;
                data.ShiftID = b.ShiftID;
                data.Status = 1;
                data.ModifiedBy = 1;
                data.ModifiedDate = System.DateTime.Today.Date;
                if (httpRequest.Files.Count == 0)
                {
                    db.SaveChanges();
                    return new Result
                    {

                        IsSucess = true,
                        ResultData = "Employee Updated!"
                    };
                }
                else
                {
                    var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "EmployeeUpload" + ("\\"));
                 if (!Directory.Exists(uploaddirc))
                 {
                    DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                 }
                 string paths = "EmployeeUpload";
                    for (int i = 0; i < httpRequest.Files.Count; i++)
                    {
                        var uploadpath = Path.Combine(HttpContext.Current.Server.MapPath("/"), paths, Upload.ToString() + ("\\"));
                        if (!Directory.Exists(uploadpath))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(uploadpath);
                        }
                        if (i == 0 && Profile != null)
                        {
                            var file = httpRequest.Files[i];
                            var Guids = Guid.NewGuid();
                            filePathSave = uploadpath + Guids;
                            filePath = filePathSave + file.FileName;

                            savePath = uploadpath;
                            file.SaveAs(filePath);
                            data.ImagePath = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
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
                            data.Sign = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                            //string Banner1 = data.Banner.Replace("~/", "");
                            //data.Banner = Banner1;
                        }
                    }
                    db.SaveChanges();
                    return new Result
                    {

                        IsSucess = true,
                        ResultData = "Employee Updated!"
                    };


                }
               
               
              
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object UpdateEmployeeAddress(EmployeeAddressParam b)
        {
            try
            {
                var Info = db.Tbl_EmployeeAddressDetails.Where(r => r.EmployeeID==b.EmployeeID).FirstOrDefault();

                //save AddressDetails
                Tbl_EmployeeAddressDetails objadd = new Tbl_EmployeeAddressDetails();
                Info.EmployeeID = Info.EmployeeID;
                Info.PermanentAddress = b.PermanentAddress;
                Info.PermanantStateID = b.PermanantStateID;
                Info.PermanantDistrictID = b.PermanantDistrictID;
                Info.PermanantTalukaID = b.PermanantTalukaID;
                Info.PermanantPincode = b.PermanantPincode;
                Info.PermanentCountry = b.PermanentCountry;
                Info.CorrespondanceAddress = b.CorrespondanceAddress;
                Info.CorrespondanceStateID = b.CorrespondanceStateID;
                Info.CorrespondanceDistrictID = b.CorrespondanceDistrictID;
                Info.CorrespondanceTalukaID = b.CorrespondanceTalukaID;
                Info.CorrespondancePincode = b.CorrespondancePincode;
                Info.CorrespondanceCountry = b.CorrespondanceCountry;
                //Info.CreatedBy = null;
                //Info.CreatedDate = System.DateTime.Today.Date;
                Info.ModifiedBy = null;
                Info.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Upadted Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object UpdateEmployeeEducation(List<EmployeeEducationUpdate> b)
        {
            try
            {
                //Update Education Details
                Tbl_EmployeeEducationDetails objedu = new Tbl_EmployeeEducationDetails();
                var EmpID = b[0].EducationID;
                var Data = db.Tbl_EmployeeEducationDetails.Where(r => r.EducationID == EmpID && r.Status == 1).ToList();
                var Info = db.Tbl_EmployeeEducationDetails.First(r => r.EducationID == EmpID);
                if (Data.Count == b.Count)
                {
                    for (int i = 0; i < Data.Count; i++)
                    {
                        objedu.EmployeeID = Data[i].EmployeeID;
                        objedu.CourseName = Data[i].CourseName;
                        objedu.PassingMothYear = Data[i].PassingMothYear;
                        objedu.SchoolCollege = Data[i].SchoolCollege;
                        objedu.UniversityBoard = Data[i].UniversityBoard;
                        objedu.BoardDivisionState = Data[i].BoardDivisionState;
                        objedu.CreditPercentageSGPA = Data[i].CreditPercentageSGPA;
                        objedu.ModifiedBy = null;
                        objedu.ModifiedDate = System.DateTime.Today.Date;
                        objedu.Status = 1;
                        db.Tbl_EmployeeEducationDetails.Add(objedu);
                        db.SaveChanges();
                    }
                }
                else
                {


                    for (int i = 0; i < b.Count; i++)
                    {
                        if (b[i].EducationID == 0)
                        {
                            objedu.EmployeeID= Info.EmployeeID;
                            objedu.CourseName = b[i].CourseName;
                            objedu.PassingMothYear = b[i].PassingMothYear;
                            objedu.SchoolCollege = b[i].SchoolCollege;
                            objedu.UniversityBoard = b[i].UniversityBoard;
                            objedu.BoardDivisionState = b[i].BoardDivisionState;
                            objedu.CreditPercentageSGPA = b[i].CreditPercentageSGPA;
                            objedu.ModifiedBy = null;
                            objedu.ModifiedDate = System.DateTime.Today.Date;
                            objedu.Status = 1;
                            db.Tbl_EmployeeEducationDetails.Add(objedu);
                            db.SaveChanges();
                        }
                        else
                        {
                            var ID = b[i].EducationID;
                           //var Info = db.Tbl_EmployeeEducationDetails.First(r => r.EducationID == ID);
                            Info.EmployeeID = Info.EmployeeID;
                            Info.CourseName = b[i].CourseName;
                            Info.PassingMothYear = b[i].PassingMothYear;
                            Info.SchoolCollege = b[i].SchoolCollege;
                            Info.UniversityBoard = b[i].UniversityBoard;
                            Info.BoardDivisionState = b[i].BoardDivisionState;
                            Info.CreditPercentageSGPA = b[i].CreditPercentageSGPA;
                            Info.ModifiedBy = null;
                            Info.ModifiedDate = System.DateTime.Today.Date;
                            db.SaveChanges();
                        }
                    }


                }
                return new Result() { IsSucess = true, ResultData = "Updated Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object UpdateEmployeeAppointment(EmployeeAppointmentParam b)
        {
            try
            {
                var Info = db.Tbl_EmployeeAppointmentDetails.Where(r => r.EmployeeID==b.EmployeeID).FirstOrDefault();

                //Save AppointmentDetails
                Tbl_EmployeeAppointmentDetails objapp = new Tbl_EmployeeAppointmentDetails();
                Info.EmployeeID = Info.EmployeeID;
                Info.AppointmentType = b.AppointmentType;
                Info.JobType = b.JobType;
                Info.JoiningDate = b.JoiningDate;
                if(b.SrGradeScaleApplicable=="No" &&b.SelectionGradeScaleApplicable=="No")
                {
                    Info.SrGradeScaleApplicableDate = null;
                    Info.SelectionGradeScaleApplicableDate = null;
                }
                else
                {
                    Info.SrGradeScaleApplicableDate = b.SrGradeScaleApplicableDate;
                    Info.SelectionGradeScaleApplicableDate = b.SelectionGradeScaleApplicableDate;

                }
                Info.SrGradeScaleApplicable = b.SrGradeScaleApplicable;
                Info.SelectionGradeScaleApplicable = b.SelectionGradeScaleApplicable;
                Info.ModifiedBy = null;
                Info.ModifiedDate = System.DateTime.Today.Date;
                Info.Status = 1;
                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Updated Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object UpdateEmployeeBank(EmployeeBankParam b)
        {
            try
            {
                var Info = db.Tbl_EmployeeBankDetails.Where(r => r.EmployeeID==b.EmployeeID).FirstOrDefault();

                //Save Bank Details
                Tbl_EmployeeBankDetails objbank = new Tbl_EmployeeBankDetails();
                Info.EmployeeID = Info.EmployeeID;
                Info.BankName = b.BankName;
                Info.AccountNumber = b.AccountNumber;
                Info.BranchName = b.BranchName;
                Info.IFSCCode = b.IFSCCode;
                Info.MICRCode = b.MICRCode;
                Info.UAN = b.UAN;
                Info.PF = b.PF;
                Info.ModifiedBy = null;
                Info.ModifiedDate = System.DateTime.Today.Date;
                Info.Status = 1;
               db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Updated Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object UpdateExperienceEducation(List<EmployeeExprienceUpadate> b)
        {
            try
            {
                //Save Education Details
                var EmpID = b[0].EmployeeID;
                Tbl_EmployeeExprienceDetails objedu = new Tbl_EmployeeExprienceDetails();
                var Data = db.Tbl_EmployeeExprienceDetails.Where(r => r.EmployeeID == EmpID && r.Status==1).ToList();
                var Info = db.Tbl_EmployeeExprienceDetails.First(r => r.EmployeeID == EmpID);
                if (Data.Count == b.Count)
                {

                    for (int i = 0; i < Data.Count; i++)
                    {
                        var ID = Data[i].EmployeeID;
                        //var Info = db.Tbl_EmployeeExprienceDetails.Where(r => r.EmployeeID == ID).ToList();
                        objedu.EmployeeID = ID;
                        objedu.ExprienceTypeID = b[i].ExprienceTypeID;
                        if (b[i].ExperienceDocumentType == null)
                        {
                            objedu.ExperienceDocumentType = Data[i].ExperienceDocumentType;
                        }
                        else
                        {
                            objedu.ExperienceDocumentType = b[i].ExperienceDocumentType;
                        }
                        objedu.Organization = b[i].Organization;
                        objedu.OrganizationAddress = b[i].OrganizationAddress;
                        objedu.Designation = b[i].Designation;
                        objedu.PeriodFrom = System.DateTime.Today.Date;
                        objedu.PeriodTo = System.DateTime.Today.Date;
                        objedu.TotalExprience = b[i].TotalExprience;
                        objedu.ModifiedBy = null;
                        objedu.ModifiedDate = System.DateTime.Today.Date;
                       // Data[i].Status = 1;
                        
                        db.SaveChanges();
                    }

                }
                else
                {

                    for (int i = 0; i < b.Count; i++)
                    {
                        var ID = b[i].EmployeeID;
                        
                        //Info[i].EmployeeID = ID;
                        if(b[i].ExprienceID==0)
                        {
                            objedu.ExprienceTypeID = b[i].ExprienceTypeID;
                            objedu.EmployeeID = EmpID;
                            if (b[i].ExperienceDocumentType == null)
                            {
                                objedu.ExperienceDocumentType = Info.ExperienceDocumentType;
                            }
                            else
                            {
                                objedu.ExperienceDocumentType = b[i].ExperienceDocumentType;
                            }
                            objedu.Organization = b[i].Organization;
                            objedu.OrganizationAddress = b[i].OrganizationAddress;
                            objedu.Designation = b[i].Designation;
                            objedu.PeriodFrom = System.DateTime.Today.Date;
                            objedu.PeriodTo = System.DateTime.Today.Date;
                            objedu.TotalExprience = b[i].TotalExprience;
                            objedu.ModifiedBy = null;
                            objedu.ModifiedDate = System.DateTime.Today.Date;
                            objedu.Status = 1;
                            db.Tbl_EmployeeExprienceDetails.Add(objedu);
                            db.SaveChanges();
                        }
                        else
                        {
                            Info.ExprienceTypeID = b[i].ExprienceTypeID;
                            if (b[i].ExperienceDocumentType == null)
                            {
                                b[i].ExperienceDocumentType = Info.ExperienceDocumentType;
                            }
                            else
                            {
                                b[i].ExperienceDocumentType = Info.ExperienceDocumentType;
                            }
                            Info.Organization = b[i].Organization;
                            Info.OrganizationAddress = b[i].OrganizationAddress;
                            Info.Designation = b[i].Designation;
                            Info.PeriodFrom = System.DateTime.Today.Date;
                            Info.PeriodTo = System.DateTime.Today.Date;
                            Info.TotalExprience = b[i].TotalExprience;
                            Info.ModifiedBy = null;
                            Info.ModifiedDate = System.DateTime.Today.Date;
                            Info.Status = 1;
                            //db.Tbl_EmployeeExprienceDetails.Add(Info[i]);
                            db.SaveChanges();
                        }
                       
                    }
                }

                return new Result() { IsSucess = true, ResultData = "Updated Employee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetEmployeeExperienceUpdate(EmployeeExprienceUpadate obj)
        {

            try
            {
                var data = db.Tbl_EmployeeExprienceDetails.Where(r => r.EmployeeID == obj.EmployeeID && r.ExprienceID == obj.ExprienceID).First();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Employee  Not Found" };
                }

                data.Status = 0;
                db.SaveChanges();
                return new Result
                {

                    IsSucess = true,
                    ResultData = "Employee Details Updated!"
                };
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object Delete(EmplyeeMasterUpadateParam s)
        {
            try
            {
                Tbl_EmployeeMaster objuser = db.Tbl_EmployeeMaster.Where(r => r.EmployeeID == s.EmployeeID).FirstOrDefault();
                Tbl_EmployeeAddressDetails add = new Tbl_EmployeeAddressDetails();
                Tbl_EmployeeAppointmentDetails app = new Tbl_EmployeeAppointmentDetails();
                Tbl_EmployeeAttachedDocuments doc = new Tbl_EmployeeAttachedDocuments();
                Tbl_EmployeeBankDetails bank = new Tbl_EmployeeBankDetails();
                Tbl_EmployeeEducationDetails edu = new Tbl_EmployeeEducationDetails();
                Tbl_EmployeeExprienceDetails ex = new Tbl_EmployeeExprienceDetails();
                if (objuser.Status == 1)
                {
                    objuser.Status = 0;
                    add.Status = 0;
                    app.Status = 0;
                    doc.Status = 0;
                    bank.Status = 0;
                    edu.Status = 0;
                    ex.Status = 0;
                 

                }
                else
                {
                    objuser.Status = 1;
                    add.Status = 1;
                    app.Status = 1;
                    doc.Status = 1;
                    bank.Status =1;
                    edu.Status = 1;
                    ex.Status = 1;
                }
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Deactivted" };

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

    }
}
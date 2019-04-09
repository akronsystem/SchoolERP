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
    public class InstituteBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
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
        public object SaveInstitute(InstituteParam obj)
        {
            try
            {
                Tbl_Institute_Master objinst = new Tbl_Institute_Master();
                objinst.AffilationNo = obj.AffilationNo;
                objinst.BoardId = obj.BoardId;
                objinst.InstituteName = obj.InstituteName;
                objinst.EstablishedYear = obj.EstablishedYear;
                objinst.InstituteOrganizationName = obj.InstituteOrganizationName;
                //objinst.InstituteRecognitionNoPrimary = obj.InstituteRecognitionNoPrimary;
                objinst.OrganizationAddress = obj.OrganizationAddress;
                objinst.OrganizationRegistrationNo = obj.OrganizationRegistrationNo;
                //objinst.RegistrationCertificateNo = obj.RegistrationCertificateNo;
                objinst.SectionId = obj.SectionId;
                objinst.UdiseNo = obj.UdiseNo;
                objinst.CreatedId = obj.CreatedId;
                objinst.CreatedOn = System.DateTime.Now.Date;
                objinst.ModifiedId = obj.ModifiedId;
                objinst.ModifiedOn =null;
                objinst.Status = 1;
                db.Tbl_Institute_Master.Add(objinst);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Institute" };
            }
            catch(Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object SaveAddressInstitute(InstituteAddressDetailsParam obj)
        {
            try
            {
                var data = db.Tbl_Institute_Master.OrderByDescending(r => r.InstituteId).FirstOrDefault();
                Tbl_Institute_Address_Details objinst = new Tbl_Institute_Address_Details();
                objinst.InstituteId = data.InstituteId;
                objinst.Address1 = obj.Address1;
                objinst.Address2 = obj.Address2;
                objinst.CityName = obj.CityName;
                objinst.Fax = obj.Fax;
                objinst.InstituteEmail = obj.InstituteEmail;
                objinst.LandlineNumber = obj.LandlineNumber;
                objinst.PhoneNumber1 = obj.PhoneNumber1;
                objinst.PhoneNumber2 = obj.PhoneNumber2;
                objinst.Pincode = obj.Pincode;
                objinst.PrinciaplEmail = obj.PrinciaplEmail;
                objinst.StateId = obj.StateId;
                objinst.Website = obj.Website;
                objinst.CreatedId = obj.CreatedId;                
                objinst.ModifiedOn = System.DateTime.Now.Date;
                objinst.CreatedOn = System.DateTime.Now.Date;
                objinst.ModifiedId = null;
                objinst.Status = 1;
                db.Tbl_Institute_Address_Details.Add(objinst);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Institute" };
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object SaveBankInstitute(InstituteBankParam obj)
        {
            try
            {
                var data = db.Tbl_Institute_Master.OrderByDescending(r => r.InstituteId).FirstOrDefault();
                Tbl_Institute_Bank_Details objinst = new Tbl_Institute_Bank_Details();
                objinst.InstituteId = data.InstituteId;
                objinst.BankName = obj.BankName;
                objinst.AccountNumber = obj.AccountNumber;
                objinst.IndexNo = obj.IndexNo;
                objinst.PanNo = obj.PanNo;
                objinst.TanNo = obj.TanNo;
                objinst.Gstin = obj.Gstin;
                objinst.Ifsc = obj.Ifsc;
                objinst.Micr = obj.Micr;
                objinst.CreatedId = obj.CreatedId;
                objinst.CreatedOn = System.DateTime.Now.Date;
                objinst.ModifiedOn = System.DateTime.Now.Date;
                objinst.ModifiedId = null;
                objinst.Status = 1;
                db.Tbl_Institute_Bank_Details.Add(objinst);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Institute" };
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object SaveLogoInstitute()
        {
            try
            {
                InstituteLogoParam obj = new InstituteLogoParam();
                var data = db.Tbl_Institute_Master.OrderByDescending(r => r.InstituteId).FirstOrDefault();
                Tbl_Institute_Logo_Details objinst = new Tbl_Institute_Logo_Details();
                var Profile = System.Web.HttpContext.Current.Request.Files["HeaderName"];
                var Sign = System.Web.HttpContext.Current.Request.Files["LogoName"];

                objinst.InstituteId = data.InstituteId;
                var httpRequest = HttpContext.Current.Request;
                string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                string fileLogo = string.Empty;
                string fileBanner = string.Empty;
                var filePath = string.Empty;
                string savePath = string.Empty;
                var filePathBanner = string.Empty;
                var filePathSave = string.Empty;
                var Upload = obj.InstituteId;
                objinst.CreatedId = obj.CreatedId;
                objinst.CreatedOn = System.DateTime.Today.Date;
                objinst.ModifiedOn = System.DateTime.Today.Date;
                objinst.ModifiedId = null;
                // objinst.Status = 1;
                var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "InstituteUpload" + ("\\"));
                if (!Directory.Exists(uploaddirc))
                {
                    DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                }
                string paths = "InstituteUpload";
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
                        objinst.LogoName = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
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
                        objinst.HeaderName = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                        //string Banner1 = data.Banner.Replace("~/", "");
                        //data.Banner = Banner1;
                    }


                }
                db.Tbl_Institute_Logo_Details.Add(objinst);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Institute" };
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetBoard(UserCredential obj)
        {
            try
            {
                List<View_Display_Board> board = null;

                if (obj.Status == "0")
                {
                    board = db.View_Display_Board.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    board = db.View_Display_Board.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    board = db.View_Display_Board.Where(r => r.Status == 1).ToList();

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
        public object GetInstitute(UserCredential obj)
        {
            try
            {
                List<View_InstituteList> Employee = null;

                if (obj.Status == "Deactive")
                {
                    Employee = db.View_InstituteList.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Employee = db.View_InstituteList.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Employee = db.View_InstituteList.Where(r => r.Status == 1).ToList();

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
        public object GetInstituteInfo(InstituteUpdateParam obj)
        {

            try
            {
                var schoolid = db.View_InstituteList.Where(r => r.InstituteId == obj.InstituteId).FirstOrDefault();
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
        public object UpdateInstitute(InstituteUpdateParam obj)
        {

            try
            {
                Tbl_Institute_Master objinst = new Tbl_Institute_Master();
                var data = db.Tbl_Institute_Master.Where(r => r.InstituteId == obj.InstituteId).FirstOrDefault();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Institute  Not Found" };
                }
                data.AffilationNo = obj.AffilationNo;
                data.BoardId = obj.BoardId;
                data.EstablishedYear = obj.EstablishedYear;
                data.InstituteName = obj.InstituteName;
                data.InstituteOrganizationName = obj.InstituteOrganizationName;
                //objinst.InstituteRecognitionNoPrimary = obj.InstituteRecognitionNoPrimary;
                data.OrganizationAddress = obj.OrganizationAddress;
                data.OrganizationRegistrationNo = obj.OrganizationRegistrationNo;
                //objinst.RegistrationCertificateNo = obj.RegistrationCertificateNo;
                data.SectionId = obj.SectionId;
                data.UdiseNo = obj.UdiseNo;
                //data.CreatedId = obj.CreatedId;
                //data.CreatedOn = System.DateTime.Now.Date;
                data.ModifiedId = obj.ModifiedId;
                data.ModifiedOn = null;
                data.Status = 1;                
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Updated Institute" };

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateInstituteAddress(InstituteAdressUpdateParam obj)
        {
            try
            {
                var data = db.Tbl_Institute_Address_Details.Where(r => r.InstituteId==obj.InstituteId).FirstOrDefault();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Institute  Not Found" };
                }
                Tbl_Institute_Address_Details objinst = new Tbl_Institute_Address_Details();
                data.InstituteId = data.InstituteId;
                data.Address1 = obj.Address1;
                data.Address2 = obj.Address2;
                data.CityName = obj.CityName;
                data.Fax = obj.Fax;
                data.InstituteEmail = obj.InstituteEmail;
                data.LandlineNumber = obj.LandlineNumber;
                data.PhoneNumber1 = obj.PhoneNumber1;
                data.PhoneNumber2 = obj.PhoneNumber2;
                data.Pincode = obj.Pincode;
                data.PrinciaplEmail = obj.PrinciaplEmail;
                data.StateId = obj.StateId;
                data.Website = obj.Website;
                //data.CreatedId = obj.CreatedId;
                data.ModifiedOn = System.DateTime.Now.Date;
                //data.CreatedOn = System.DateTime.Now.Date;
                data.ModifiedId = null;
                data.Status = 1;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Updated Institute" };

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateInstituteBank(InstituteBankUpdateParam obj)
        {
            try
            {
                var data = db.Tbl_Institute_Bank_Details.Where(r => r.InstituteId==obj.InstituteId).FirstOrDefault();
                Tbl_Institute_Bank_Details objinst = new Tbl_Institute_Bank_Details();
                data.InstituteId = data.InstituteId;
                data.BankName = obj.BankName;
                data.AccountNumber = obj.AccountNumber;
                data.IndexNo = obj.IndexNo;
                data.PanNo = obj.PanNo;
                data.TanNo = obj.TanNo;
                data.Gstin = obj.Gstin;
                data.Ifsc = obj.Ifsc;
                data.Micr = obj.Micr;
                //objinst.CreatedId = obj.CreatedId;
                //objinst.CreatedOn = System.DateTime.Now.Date;
                data.ModifiedOn = System.DateTime.Now.Date;
                data.ModifiedId = null;
                data.Status = 1;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Updated Institute" };

            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object UpdateInstituteLogo(InstituteLogoUpdateParam obj)
        {
            try
            {
                //InstituteLogoUpdateParam obj = new InstituteLogoUpdateParam();
                
                Tbl_Institute_Logo_Details objinst = new Tbl_Institute_Logo_Details();
                var Profile = System.Web.HttpContext.Current.Request.Files["HeaderName"];
                var Sign = System.Web.HttpContext.Current.Request.Files["LogoName"];
                var json = System.Web.HttpContext.Current.Request.Form["Data"];
                InstituteLogoUpdateParam b = Newtonsoft.Json.JsonConvert.DeserializeObject<InstituteLogoUpdateParam>(json);
                var data = db.Tbl_Institute_Logo_Details.Where(r => r.InstituteId == b.InstituteId).FirstOrDefault();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "Institute  Not Found" };
                }
                data.InstituteId = data.InstituteId;
                var httpRequest = HttpContext.Current.Request;
                string UploadBaseUrl = ConfigurationManager.AppSettings["UploadBaseURL"];
                string fileLogo = string.Empty;
                string fileBanner = string.Empty;
                var filePath = string.Empty;
                string savePath = string.Empty;
                var filePathBanner = string.Empty;
                var filePathSave = string.Empty;
                var Upload = obj.InstituteId;
                //objinst.CreatedId = obj.CreatedId;
                //objinst.CreatedOn = System.DateTime.Today.Date;
                data.ModifiedOn = System.DateTime.Today.Date;
                data.ModifiedId = null;
                // objinst.Status = 1;
                if (httpRequest.Files.Count == 0)
                {
                    db.SaveChanges();
                    return new Result
                    {

                        IsSucess = true,
                        ResultData = "Institute Updated!"
                    };
                }
                else
                {
                    var uploaddirc = Path.Combine(HttpContext.Current.Server.MapPath("/"), "InstituteUpload" + ("\\"));
                    if (!Directory.Exists(uploaddirc))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(uploaddirc);
                    }
                    string paths = "InstituteUpload";
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
                            data.LogoName = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("/") + Guids + file.FileName;
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
                            data.HeaderName = UploadBaseUrl + paths + ("/") + Upload.ToString() + ("\\") + GuidsBanner + file.FileName;
                            //string Banner1 = data.Banner.Replace("~/", "");
                            //data.Banner = Banner1;
                        }


                    }

                    db.SaveChanges();
                    return new Result() { IsSucess = true, ResultData = "Updated Institute" };
                }
            }
            catch (Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }
        public object Delete(InstituteUpdateParam s)
        {
            try
            {
                Tbl_Institute_Master objuser = db.Tbl_Institute_Master.Where(r => r.InstituteId == s.InstituteId).FirstOrDefault();
                Tbl_Institute_Address_Details add = new Tbl_Institute_Address_Details();
                Tbl_Institute_Bank_Details app = new Tbl_Institute_Bank_Details();
                Tbl_Institute_Logo_Details doc = new Tbl_Institute_Logo_Details();
            
                if (objuser.Status == 1)
                {
                    objuser.Status = 0;
                    add.Status = 0;
                    app.Status = 0;
                   
                   


                }
                else
                {
                    objuser.Status = 1;
                    add.Status = 1;
                    app.Status = 1;
                   
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
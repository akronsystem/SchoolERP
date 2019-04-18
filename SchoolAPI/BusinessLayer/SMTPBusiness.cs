using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class SMTPBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveSMTP(SMTPParam b)
        {
            if (b.Host == null)
            {
                return new Error() { IsError = true, Message = "Required Host" };
            }
            var data = db.Tbl_SMTPConfiguration.FirstOrDefault(r => r.Host == b.Host);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_SMTPConfiguration obj = new Tbl_SMTPConfiguration();
                obj.Port = b.Port;
                obj.Secure = b.Secure;
                obj.Host = b.Host;
                obj.UserName = b.UserName;
                obj.Password = b.Password;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_SMTPConfiguration.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created SMTP" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object SMTPUpdate(SMTPUpdatePram b)
        {
            if (b.Port == 0)
            {
                return new Error() { IsError = true, Message = "Required Port" };
            }
            var Info = db.Tbl_SMTPConfiguration.Where(r => r.UserName == b.UserName).FirstOrDefault();
            if(Info==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_SMTPConfiguration.Where(r => r.ConfigurationID == b.ConfigurationID).FirstOrDefault();
            try
            {
                Tbl_SMTPConfiguration obj = new Tbl_SMTPConfiguration();
                data.Port = b.Port;
                data.Secure = b.Secure;
                data.Host = b.Host;
                data.UserName = b.UserName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update SMTP" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetSMTP(UserCredential obj)
        {
            try
            {
                List<ViewSMTPList> SMTP = null;

                if (obj.Status == "0")
                {
                    SMTP = db.ViewSMTPLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    SMTP = db.ViewSMTPLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    SMTP = db.ViewSMTPLists.Where(r => r.Status == 1).ToList();

                }

                if (SMTP == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return SMTP;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleSMTP(SMTPUpdatePram b)
        {
            try
            {
                var board = db.ViewSMTPLists.Where(r => r.ConfigurationID == b.ConfigurationID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = board };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteSMTP(SMTPUpdatePram PM)
        {
            try
            {
                Tbl_SMTPConfiguration obj = db.Tbl_SMTPConfiguration.Where(r => r.ConfigurationID == PM.ConfigurationID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "SMTP Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
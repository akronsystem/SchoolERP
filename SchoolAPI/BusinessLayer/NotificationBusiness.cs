using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class NotificationBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveNotificationType(NotificationTypeParam b)
        {
            if (b.Notification == null)
            {
                return new Error() { IsError = true, Message = "Required Notification" };
            }
            var data = db.Tbl_NotificationType.FirstOrDefault(r => r.Notification == b.Notification);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_NotificationType obj = new Tbl_NotificationType();
                obj.Notification = b.Notification;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_NotificationType.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Notification" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object NotificationTypeUpdate(NotificationTypeUpdateParam b)
        {
            if (b.Notification == null)
            {
                return new Error() { IsError = true, Message = "Required Notification" };
            }
            var Info = db.Tbl_NotificationType.Where(r => r.Notification == b.Notification).FirstOrDefault();
            if(Info==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_NotificationType.Where(r => r.NotificationTypeID == b.NotificationTypeID).FirstOrDefault();
            try
            {
                Tbl_NotificationType obj = new Tbl_NotificationType();
                data.Notification = b.Notification;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Notification" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetNotificationType(UserCredential obj)
        {
            try
            {
                List<ViewNotificationTypeList> Notification = null;

                if (obj.Status == "0")
                {
                    Notification = db.ViewNotificationTypeLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Notification = db.ViewNotificationTypeLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Notification = db.ViewNotificationTypeLists.Where(r => r.Status == 1).ToList();

                }

                if (Notification == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Notification;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleNotificationType(NotificationTypeUpdateParam b)
        {
            try
            {
                var Event = db.ViewNotificationTypeLists.Where(r => r.NotificationTypeID == b.NotificationTypeID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = Event };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteNotificationType(NotificationTypeUpdateParam PM)
        {
            try
            {
                Tbl_NotificationType obj = db.Tbl_NotificationType.Where(r => r.NotificationTypeID == PM.NotificationTypeID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Notification Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
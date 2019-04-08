using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class EventTypeBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveEventType(EventTypeParam b)
        {
            if (b.EventType == null)
            {
                return new Error() { IsError = true, Message = "Required EventType" };
            }
            var data = db.Tbl_EventType_Master.FirstOrDefault(r => r.EventType == b.EventType);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_EventType_Master obj = new Tbl_EventType_Master();
                obj.EventType = b.EventType;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_EventType_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Event Type" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object EventTypeUpdate(EventTypeUpdateParam b)
        {
            if (b.EventType == null)
            {
                return new Error() { IsError = true, Message = "Required Event Type" };
            }
            var Info = db.Tbl_EventType_Master.FirstOrDefault(r => r.EventType == b.EventType);
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_EventType_Master.Where(r => r.EventTypeID == b.EventTypeID).FirstOrDefault();
            try
            {
                Tbl_FeeType_Master obj = new Tbl_FeeType_Master();
                data.EventType = b.EventType;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Event Type" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetEventType(UserCredential obj)
        {
            try
            {
                List<ViewEventTypeList> Event = null;

                if (obj.Status == "0")
                {
                    Event = db.ViewEventTypeLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Event = db.ViewEventTypeLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Event = db.ViewEventTypeLists.Where(r => r.Status == 1).ToList();

                }

                if (Event == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Event;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleEventType(EventTypeUpdateParam b)
        {
            try
            {
                var Event = db.ViewEventTypeLists.Where(r => r.EventTypeID == b.EventTypeID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = Event };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteEventType(EventTypeUpdateParam PM)
        {
            try
            {
                Tbl_EventType_Master obj = db.Tbl_EventType_Master.Where(r => r.EventTypeID == PM.EventTypeID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Event Type Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        //Event Master
        public object SaveEvent(EventMasterParam b)
        {
            if (b.EventTypeID == 0)
            {
                return new Error() { IsError = true, Message = "Required EventType" };
            }
            var data = db.Tbl_EventMaster.FirstOrDefault(r => r.EventName == b.EventName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_EventMaster obj = new Tbl_EventMaster();
                obj.EventTypeID = b.EventTypeID;
                obj.EventName = b.EventName;
                obj.StartDate = b.StartDate;
                obj.EndDate = b.EndDate;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_EventMaster.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Event" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object EventUpdate(EventMasterUpdateParam b)
        {
            if (b.EventTypeID == 0)
            {
                return new Error() { IsError = true, Message = "Required Event Type" };
            }
            var Info = db.Tbl_EventMaster.FirstOrDefault(r => r.EventName == b.EventName);
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_EventMaster.Where(r => r.EventID == b.EventID).FirstOrDefault();
            try
            {
                Tbl_EventMaster obj = new Tbl_EventMaster();
                data.EventID = b.EventID;
                data.EventName = b.EventName;
                data.StartDate = b.StartDate;
                data.EndDate = b.EndDate;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Event" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetEvent(UserCredential obj)
        {
            try
            {
                List<ViewEventMasterList> Event = null;

                if (obj.Status == "0")
                {
                    Event = db.ViewEventMasterLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Event = db.ViewEventMasterLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Event = db.ViewEventMasterLists.Where(r => r.Status == 1).ToList();

                }

                if (Event == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Event;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleEvent(EventMasterUpdateParam b)
        {
            try
            {
                var Event = db.ViewEventMasterLists.Where(r => r.EventID == b.EventID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = Event };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteEvent(EventMasterUpdateParam PM)
        {
            try
            {
                Tbl_EventMaster obj = db.Tbl_EventMaster.Where(r => r.EventID == PM.EventID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Event Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
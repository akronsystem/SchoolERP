using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class WidgetBusiness
    {
        SchoolERPContext db = new SchoolERPContext();
        public object SaveWidget(WidgetParam b)
        {
            if (b.WidgetName == null)
            {
                return new Error() { IsError = true, Message = "Required WidgetName" };
            }
            var data = db.Tbl_Widget_Master.FirstOrDefault(r => r.WidgetName == b.WidgetName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Widget_Master obj = new Tbl_Widget_Master();
                obj.WidgetName = b.WidgetName;
                obj.ActionName = b.ActionName;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Widget_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Widget Created Successfully!" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object WidgetUpdate(WidgetUpdateParam b)
        {
            if (b.WidgetName == null)
            {
                return new Error() { IsError = true, Message = "Required Widget Name" };
            }
            var data = db.Tbl_Widget_Master.Where(r => r.WidgetID == b.WidgetID).FirstOrDefault();
            var Info = db.Tbl_Widget_Master.Where(r => r.WidgetName == b.WidgetName).FirstOrDefault();
            if(Info==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Widget_Master obj = new Tbl_Widget_Master();
                data.WidgetName = b.WidgetName;
                data.ActionName = b.ActionName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Widget Updated Successfully!" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetWidget(UserCredential obj)
        {
            try
            {
                List<ViewWidgetList> widget = null;

                if (obj.Status == "0")
                {
                    widget = db.ViewWidgetLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    widget = db.ViewWidgetLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    widget = db.ViewWidgetLists.Where(r => r.Status == 1).ToList();

                }

                if (widget == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return widget;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleWidget(WidgetUpdateParam b)
        {
            try
            {
                var widget = db.ViewWidgetLists.Where(r => r.WidgetID == b.WidgetID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = widget };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteWidget(WidgetUpdateParam PM)
        {
            try
            {
                Tbl_Widget_Master obj = db.Tbl_Widget_Master.Where(r => r.WidgetID == PM.WidgetID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Widget Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
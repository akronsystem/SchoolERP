using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class ShiftBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveShift(ShiftMasterParam b)
        {
            if (b.ShiftName == null)
            {
                return new Error() { IsError = true, Message = "Required ShiftName" };
            }
            var data = db.Tbl_Shift_Master.FirstOrDefault(r => r.ShiftName == b.ShiftName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Shift_Master obj = new Tbl_Shift_Master();
                obj.ShiftName = b.ShiftName;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Shift_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Shift" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object ShiftUpdate(ShiftMasterUpdateParam b)
        {
            if (b.ShiftName == null)
            {
                return new Error() { IsError = true, Message = "Required ShiftName" };
            }
            var Data = db.Tbl_Shift_Master.Where(r => r.ShiftName == b.ShiftName).FirstOrDefault();
            if(Data==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_Shift_Master.Where(r => r.ShiftID == b.ShiftID).FirstOrDefault();
            try
            {
                Tbl_Shift_Master obj = new Tbl_Shift_Master();
                data.ShiftName = b.ShiftName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Shift" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetShift(UserCredential obj)
        {
            try
            {
                List<ViewShiftList> data = null;

                if (obj.Status == "0")
                {
                    data = db.ViewShiftLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    data = db.ViewShiftLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    data = db.ViewShiftLists.Where(r => r.Status == 1).ToList();

                }

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
        public object GetSingleShift(ShiftMasterUpdateParam b)
        {
            try
            {
                var shift = db.ViewShiftLists.Where(r => r.ShiftID == b.ShiftID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = shift };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteShift(ShiftMasterUpdateParam PM)
        {
            try
            {
                Tbl_Shift_Master obj = db.Tbl_Shift_Master.Where(r => r.ShiftID == PM.ShiftID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Shift Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        //Shift Details
        public object SaveShiftDetails(ShiftDetailsParam b)
        {
            if (b.ShiftID == 0)
            {
                return new Error() { IsError = true, Message = "Required ShiftName" };
            }
            var data = db.Tbl_Shift_Details.Where(r => r.ShiftID == b.ShiftID).FirstOrDefault();
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Shift_Details obj = new Tbl_Shift_Details();
                obj.ShiftID = b.ShiftID;
                obj.InTime = DateTime.Parse(b.InTime).TimeOfDay;
                obj.OutTime = DateTime.Parse(b.OutTime).TimeOfDay;
                obj.LateMark = DateTime.Parse(b.LateMark).TimeOfDay;
                obj.EarlyGoing = DateTime.Parse(b.EarlyGoing).TimeOfDay;
                obj.HalfDayEarly = DateTime.Parse(b.HalfDayEarly).TimeOfDay;
                obj.HalfDayLate = DateTime.Parse(b.HalfDayLate).TimeOfDay;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Shift_Details.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created ShiftDetails" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object ShiftDetailsUpdate(ShiftDetailsUpdateParam b)
        {
            if (b.ShiftID == 0)
            {
                return new Error() { IsError = true, Message = "Required ShiftName" };
            }
            var data = db.Tbl_Shift_Details.Where(r => r.ShiftDetailID == b.ShiftDetailID).FirstOrDefault();
            try
            {
                Tbl_Shift_Details obj = new Tbl_Shift_Details();
                data.ShiftID = b.ShiftID;
                data.InTime = DateTime.Parse(b.InTime).TimeOfDay;
                data.OutTime = DateTime.Parse(b.OutTime).TimeOfDay;                
                data.LateMark = DateTime.Parse(b.LateMark).TimeOfDay;
                data.EarlyGoing = DateTime.Parse(b.EarlyGoing).TimeOfDay;
                data.HalfDayEarly = DateTime.Parse(b.HalfDayEarly).TimeOfDay;
                data.HalfDayLate = DateTime.Parse(b.HalfDayLate).TimeOfDay;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update ShiftDetails" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetShiftDetails(UserCredential obj)
        {
            try
            {
                List<ViewShiftDetailsList> data = null;

                if (obj.Status == "0")
                {
                    data = db.ViewShiftDetailsLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    data = db.ViewShiftDetailsLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    data = db.ViewShiftDetailsLists.Where(r => r.Status == 1).ToList();

                }

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
        public object GetSingleShiftDetails(ShiftDetailsUpdateParam b)
        {
            try
            {
                var shift = db.ViewShiftDetailsLists.Where(r => r.ShiftDetailID == b.ShiftDetailID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = shift };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteShiftDetails(ShiftDetailsUpdateParam PM)
        {
            try
            {
                Tbl_Shift_Details obj = db.Tbl_Shift_Details.Where(r => r.ShiftDetailID == PM.ShiftDetailID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "ShiftDetails Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
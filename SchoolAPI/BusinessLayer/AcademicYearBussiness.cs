using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class AcademicYearBussiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveAcademic(AcademicParam b)
        {
            if (b.Type == null)
            {
                return new Error() { IsError = true, Message = "Required Type" };
            }
            var data = db.Tbl_AcademicYear_Master.FirstOrDefault(r => r.Type == b.Type && r.Status==0);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_AcademicYear_Master obj = new Tbl_AcademicYear_Master();
                obj.Type = b.Type;
                obj.AcademicYear = b.AcademicYear;
                obj.StartDate = Convert.ToDateTime(b.StartDate.ToShortDateString());
                obj.EndDate =Convert.ToDateTime(b.EndDate.ToShortDateString());
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_AcademicYear_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Academic Year" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetAcademicList(UserCredential obj)
        {
            try
            {
                List<ViewAcademicYearList> Year = null;

                if (obj.Status == "0")
                {
                    Year = db.ViewAcademicYearLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Year = db.ViewAcademicYearLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Year = db.ViewAcademicYearLists.Where(r => r.Status == 1).ToList();

                }

                if (Year == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Year;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleYear(UpdateAcademicYear b)
        {
            try
            {

                var data = db.ViewAcademicYearLists.Where(r => r.AcademicID == b.AcademicID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = data };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object AcademicUpdate(UpdateAcademicYear b)
        {
            if (b.Type == null)
            {
                return new Error() { IsError = true, Message = "Required State" };
            }
            //var Info = db.Tbl_AcademicYear_Master.Where(r => r.StartDate == b.StartDate && r.EndDate == b.EndDate).FirstOrDefault();
            //if(Info==null)
            //{
            //    return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            //}
            var data = db.Tbl_AcademicYear_Master.Where(r => r.AcademicID == b.AcademicID).FirstOrDefault();
            try
            {
                Tbl_AcademicYear_Master obj = new Tbl_AcademicYear_Master();
                data.AcademicYear = b.AcademicYear;
                data.Type = b.Type;
                data.StartDate = Convert.ToDateTime(b.StartDate.ToShortDateString());
                data.EndDate = Convert.ToDateTime(b.EndDate.ToShortDateString());
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Academic" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteAcademic(UpdateAcademicYear PM)
        {
            try
            {
                Tbl_AcademicYear_Master obj = db.Tbl_AcademicYear_Master.Where(r => r.AcademicID == PM.AcademicID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "State Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
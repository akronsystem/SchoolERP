using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class ExperienceTypeBussiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveExperienceType(ExperienceTypeParam b)
        {
            if (b.ExprienceType == null)
            {
                return new Error() { IsError = true, Message = "Required ExprienceType" };
            }
            var data = db.Tbl_ExprienceType_Master.FirstOrDefault(r => r.ExprienceType == b.ExprienceType);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_ExprienceType_Master obj = new Tbl_ExprienceType_Master();
                obj.ExprienceType = b.ExprienceType;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_ExprienceType_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created ExprienceType" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object ExprienceTypeUpdate(ExperienceTypeUpdateParam b)
        {
            if (b.ExprienceType == null)
            {
                return new Error() { IsError = true, Message = "Required ExprienceType" };
            }
            var Info = db.Tbl_ExprienceType_Master.Where(r => r.ExprienceType == b.ExprienceType).FirstOrDefault();
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_ExprienceType_Master.Where(r => r.ExprienceTypeID == b.ExprienceTypeID).FirstOrDefault();
            try
            {
                Tbl_ExprienceType_Master obj = new Tbl_ExprienceType_Master();
                data.ExprienceType = b.ExprienceType;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update ExprienceType" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetExprienceType(UserCredential obj)
        {
            try
            {
                List<ViewExperienceTypeList> ExprienceType = null;

                if (obj.Status == "0")
                {
                    ExprienceType = db.ViewExperienceTypeLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    ExprienceType = db.ViewExperienceTypeLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    ExprienceType = db.ViewExperienceTypeLists.Where(r => r.Status == 1).ToList();

                }

                if (ExprienceType == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return ExprienceType;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleExprienceType(ExperienceTypeUpdateParam b)
        {
            try
            {
                var ExprienceType = db.ViewExperienceTypeLists.Where(r => r.ExprienceTypeID == b.ExprienceTypeID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = ExprienceType };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteExprienceType(ExperienceTypeUpdateParam PM)
        {
            try
            {
                Tbl_ExprienceType_Master obj = db.Tbl_ExprienceType_Master.Where(r => r.ExprienceTypeID == PM.ExprienceTypeID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "ExprienceType Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
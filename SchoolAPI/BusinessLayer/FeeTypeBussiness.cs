using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class FeeTypeBussiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveFeeType(FeeTypeParam b)
        {
            if (b.FeetType == null)
            {
                return new Error() { IsError = true, Message = "Required FeeType" };
            }
            var data = db.Tbl_FeeType_Master.FirstOrDefault(r => r.FeetType == b.FeetType);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_FeeType_Master obj = new Tbl_FeeType_Master();
                obj.FeetType = b.FeetType;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_FeeType_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Fee Type" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object FeeTypeUpdate(FeeTypeUpdateParam b)
        {
            if (b.FeetType == null)
            {
                return new Error() { IsError = true, Message = "Required Fee Type" };
            }
            var Info = db.Tbl_FeeType_Master.FirstOrDefault(r => r.FeetType == b.FeetType);
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_FeeType_Master.Where(r => r.FeeTypeID == b.FeeTypeID).FirstOrDefault();
            try
            {
                Tbl_FeeType_Master obj = new Tbl_FeeType_Master();
                data.FeetType = b.FeetType;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Fee Type" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetFeeType(UserCredential obj)
        {
            try
            {
                List<ViewFeeTypeList> FeeType = null;

                if (obj.Status == "0")
                {
                    FeeType = db.ViewFeeTypeLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    FeeType = db.ViewFeeTypeLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    FeeType = db.ViewFeeTypeLists.Where(r => r.Status == 1).ToList();

                }

                if (FeeType == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return FeeType;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleFeeType(FeeTypeUpdateParam b)
        {
            try
            {
                var FeeType = db.ViewFeeTypeLists.Where(r => r.FeeTypeID == b.FeeTypeID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = FeeType };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteFeeType(FeeTypeUpdateParam PM)
        {
            try
            {
                Tbl_FeeType_Master obj = db.Tbl_FeeType_Master.Where(r => r.FeeTypeID == PM.FeeTypeID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "FeeType Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
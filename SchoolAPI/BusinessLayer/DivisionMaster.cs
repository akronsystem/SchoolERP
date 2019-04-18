using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class DivisionMaster
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveDivision(DivisionParam DivParam)
        {
            Tbl_Division_Master obj = new Tbl_Division_Master();
            obj.DivisionName = DivParam.DivisionName;
            obj.CreatedBy = 1;
            obj.CreatedDate = DateTime.Now;
            obj.ModifiedBy = null;
            obj.ModifiedDate = null;
            obj.Status = 1;
            db.Tbl_Division_Master.Add(obj);
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Division Save Successfully" };

        }
        public object DisplayDiv(DivisionParam DivParam)
        {
            if(DivParam.Status==1)
            {
                var resultData = db.View_DisplayDivision.Where (r=>r.Status==1).ToList();
                return resultData;
            }
            else
            {
                var resultData = db.View_DisplayDivision.Where(r => r.Status == 0).ToList();
                return resultData;
            }
        }
        public object GetSingleDivision(DivisionParam DivParam)
        {
            var SingleRecord = db.Tbl_Division_Master.SingleOrDefault(r => r.DivisionID == DivParam.DivisionId);
            return SingleRecord;

        }
        public object UpdateDivision(DivisionParam DivParam)
        {
            var Data = db.Tbl_Division_Master.Where(r => r.DivisionName == DivParam.DivisionName).FirstOrDefault();
            if(Data==null)
            {
                return new Error() { IsError = true, Message = "DivisionName Already Exists!" };
            }
            Tbl_Division_Master obj = db.Tbl_Division_Master.SingleOrDefault(r => r.DivisionID == DivParam.DivisionId);
            obj.DivisionName = DivParam.DivisionName;
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Division Updated Successfully" };
        }

        public object DeleteDivision(DivisionParam DivParam)
        {

            Tbl_Division_Master obj = new Tbl_Division_Master();
                if (DivParam.Status == 0)
                {
                    obj = db.Tbl_Division_Master.SingleOrDefault(r => r.DivisionID == DivParam.DivisionId);
                    obj.Status = 1;
                    db.SaveChanges();


                    return new Result() { IsSucess = true, ResultData = "Division Activeted Successfully" };
                }
                else
                {
                    obj = db.Tbl_Division_Master.SingleOrDefault(r => r.DivisionID == DivParam.DivisionId);
                    obj.Status = 0;
                    db.SaveChanges();


                    return new Result() { IsSucess = true, ResultData = "Division Dectiveted Successfully" };
                }

            }

        

    }
}
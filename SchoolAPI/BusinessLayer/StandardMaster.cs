using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class StandardMaster
    {
        SchoolAdminContext db = new SchoolAdminContext();
        
        public object AddStandard (StandardParam StdParam)
        {
            Tbl_StandardMaster obj = new Tbl_StandardMaster();
            obj.StandardName = StdParam.StandardName;
            obj.Status = 1;
            obj.CreatedBy = 1;
            obj.CreatedDate = System.DateTime.Today.Date;
            obj.ModifiedBy = null;
            obj.ModifiedDate = null;
            db.Tbl_StandardMaster.Add(obj);
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Standard Save Successfully" };
        }



        public object GetSingleStandard(StandardParam StdParam)
        {
            var Standard = db.Tbl_StandardMaster.SingleOrDefault(r => r.StandardId == StdParam.StandardId && r.Status == 1);
           

            return new Result() { IsSucess = true, ResultData = Standard };
        }
          public object DeleteStandard(StandardParam StdParam)
        {
            Tbl_StandardMaster obj = new Tbl_StandardMaster();
            if (StdParam.Status==0)
            {
                obj = db.Tbl_StandardMaster.SingleOrDefault(r => r.StandardId == StdParam.StandardId );
                obj.Status = 1;
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Standard Activeted Successfully" };
            }
            else
            {
              obj = db.Tbl_StandardMaster.SingleOrDefault(r => r.StandardId == StdParam.StandardId);
              obj.Status = 0;
                db.SaveChanges();


                return new Result() { IsSucess = true, ResultData = "Standard Dectiveted Successfully" };
            }
            
        }


        public object GetStandardInfo(StandardParam StdParam)
        {
            List<ViewDisplayStandard> result = null;
            if (StdParam.Status == 0)
            {
                 result = db.ViewDisplayStandards.Where(r => r.Status == 0).ToList();
            }
            else
            {
                 result = db.ViewDisplayStandards.Where(r=>r.Status==1).ToList();
            }
         
            // return new Result() { IsSucess = true, ResultData = result };
            return result;
        }
        public object UpdateStandard(StandardParam StdParam)
        {
            var Data = db.Tbl_StandardMaster.Where(r => r.StandardName == StdParam.StandardName).FirstOrDefault();
            if(Data==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            Tbl_StandardMaster obj = db.Tbl_StandardMaster.SingleOrDefault(r => r.StandardId == StdParam.StandardId);

            obj.StandardName = StdParam.StandardName;
            obj.ModifiedBy = 1;
            obj.ModifiedDate = DateTime.Now;
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Standard Updated Successfully" };
        }


    }
}
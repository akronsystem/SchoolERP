using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class SectionMasterBussiness
    {

        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveSection(SectionParam objParam)
        {
            Tbl_Section_Master obj = new Tbl_Section_Master();
            obj.SectionName = objParam.SectionName;
            obj.Status = 1;
            obj.CreatedBy = 1;
            obj.CreatedDate = DateTime.Now;
            obj.ModifiedBy = null;
            obj.ModifiedDate = null;
            db.Tbl_Section_Master.Add(obj);
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Section Save Successfully" };
        }
        public object DisplaySection(SectionParam objParam)
        {
            List<View_SectionDisplay> DisplayResult = null;
            if (objParam.Status==1)
            {
                 DisplayResult = db.View_SectionDisplay.Where(r => r.Status == 1).ToList();
            }
            else
            {
                 DisplayResult = db.View_SectionDisplay.Where(r => r.Status == 0).ToList();
            }
            return DisplayResult;


        }
        public object SingleSection(SectionParam objParam)
        {
            var SingleRecord = db.Tbl_Section_Master.SingleOrDefault(r => r.SectionId == objParam.Sectionid);
            return new Result() { IsSucess=true,ResultData=SingleRecord};
        }

        public object UpdateSection(SectionParam objParam)
        {
            Tbl_Section_Master obj= db.Tbl_Section_Master.SingleOrDefault(r => r.SectionId == objParam.Sectionid);
            obj.SectionName = objParam.SectionName;
            obj.ModifiedBy = 1;
            obj.ModifiedDate = DateTime.Now;
            db.SaveChanges();
            return new Result() { IsSucess = true, ResultData = "Record Updated Successfully" };
        }
        public object DeleteSection(SectionParam objParam)
        {
          
            if(objParam.Status==1)
            {
                Tbl_Section_Master obj = db.Tbl_Section_Master.SingleOrDefault(r => r.SectionId == objParam.Sectionid && r.Status==1);
                obj.Status = 0;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Record Deactivated Successfully" };
            }
            else
            {
                Tbl_Section_Master obj = db.Tbl_Section_Master.SingleOrDefault(r => r.SectionId == objParam.Sectionid && r.Status == 0);
                obj.Status = 1;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Record Activated Successfully" };
            }
           
            
           
        }
    }
}
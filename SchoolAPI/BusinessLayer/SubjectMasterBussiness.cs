using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class SubjectMasterBussiness
    {
        SchoolERPContext db = new SchoolERPContext();
        public object SaveSubject(SubjectParam ObjParam)
        {
            try
            {
                var Duplicate = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectName == ObjParam.SubjectName && r.SubjectCode ==ObjParam.SubjectCode);
                if (Duplicate != null)
                {
                    return new Result() { IsSucess = true, ResultData = "Duplicate Entry Not Allowed" };
                }
                else
                {
                    Tbl_Subject_Master obj = new Tbl_Subject_Master();
                    obj.SubjectName = ObjParam.SubjectName;
                    obj.SubjectCode = ObjParam.SubjectCode;
                    obj.Status = 1;
                    obj.CreatedBy = 1;
                    obj.ModifiedBy = null;
                    obj.ModifiedDate = null;
                    obj.CreatedDate = DateTime.Now;
                    db.Tbl_Subject_Master.Add(obj);
                    db.SaveChanges();
                    return new Result() { IsSucess = true, ResultData = "Subject Save Successfully" };
                }
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message="Error" };
            }

        }
        public object GetSingleSubject(SubjectParam ObjParam)
        {
            Tbl_Subject_Master obj = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectID == ObjParam.SubjectId);
            return new Result() { IsSucess = true, ResultData = obj };
        }
        public object UpdateSubject(SubjectParam ObjParam)
        {
            var Duplicate = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectName == ObjParam.SubjectName && r.SubjectCode == ObjParam.SubjectCode);
            if (Duplicate != null)
            {

                return new Result() { IsSucess = true, ResultData = "Duplicate Entry Not Allowed" };
            }
            else
            {
                Tbl_Subject_Master obj = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectID == ObjParam.SubjectId);
                obj.SubjectName = ObjParam.SubjectName;
                obj.SubjectCode = ObjParam.SubjectCode;
                obj.ModifiedBy = 1;
                obj.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Record Updated Successfully" };
            }
        }
        public object DeleteSubject(SubjectParam ObjParam)
        {
            if(ObjParam.Status==1)
            {
                Tbl_Subject_Master obj = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectID == ObjParam.SubjectId && r.Status==1);
               obj.Status = 0;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Subject Deactivated Successfully" };
            }
            else
            {
                Tbl_Subject_Master obj = db.Tbl_Subject_Master.SingleOrDefault(r => r.SubjectID == ObjParam.SubjectId && r.Status == 0);

                obj.Status = 1;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Subject Activated Successfully" };
            }
            
           
        }
        public object DisplaySubject(SubjectParam ObjParam)
        {

            List<View_Display_Subject> AllSubject = new List<View_Display_Subject>();
            if(ObjParam.Status==1)
            {
                AllSubject = db.View_Display_Subject.Where(r=>r.Status==1).ToList();
            }
            else
            {
                AllSubject = db.View_Display_Subject.Where(r => r.Status == 0).ToList();
            }
            return new Result() { IsSucess=true,ResultData= AllSubject };
        }
    }
}
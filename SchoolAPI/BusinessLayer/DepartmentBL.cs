using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class DepartmentBL
    {
        SchoolAdminContext db = new SchoolAdminContext();

        public object SaveDepartment(DepartmentParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Department_Master.Where(r => r.Department == MP.Department.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Department Name Already Exists!" };
                    }
                    Tbl_Department_Master objDepartment = new Tbl_Department_Master();

                    objDepartment.Department = MP.Department.ToUpper();
                    objDepartment.CreatedBy = MP.CreatedBy;
                    objDepartment.CreatedDate = DateTime.Now;
                    objDepartment.Status = 1;
                    db.Tbl_Department_Master.Add(objDepartment);
                    db.SaveChanges();
                    msg = "Department Saved Successfully!";

                }
                else
                {
                    Tbl_Department_Master objDepartment = db.Tbl_Department_Master.Where(r => r.DepartmentID == MP.DepartmentID).FirstOrDefault();
                    var Data = db.Tbl_Department_Master.Where(r => r.Department == MP.Department.ToUpper()).FirstOrDefault();
                    if (Data != null)
                    {
                        return new Error() { IsError = true, Message = "Department Name Already Exists!" };
                    }
                    objDepartment.Department = MP.Department.ToUpper();
                    objDepartment.ModifiedDate = DateTime.Now;
                    objDepartment.DepartmentID = MP.DepartmentID;
                    db.SaveChanges();
                    msg = "Department Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object SaveDesignation(DesignationParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Designation_Master.Where(r => r.Designation == MP.Designation.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Designation Name Already Exists!" };
                    }
                    Tbl_Designation_Master objDesignation = new Tbl_Designation_Master();

                    objDesignation.Designation = MP.Designation.ToUpper();
                    objDesignation.CreatedBy = MP.CreatedBy;
                    objDesignation.CreatedDate = DateTime.Now;
                    objDesignation.Status = 1;
                    db.Tbl_Designation_Master.Add(objDesignation);
                    db.SaveChanges();
                    msg = "Designation Saved Successfully!";

                }
                else
                {
                    Tbl_Designation_Master objDesignation = db.Tbl_Designation_Master.Where(r => r.DesignationID == MP.DesignationID).FirstOrDefault();
                    var Data = db.Tbl_Designation_Master.Where(r => r.Designation == MP.Designation.ToUpper()).FirstOrDefault();
                    if (Data != null)
                    {
                        return new Error() { IsError = true, Message = "Designation Name Already Exists!" };
                    }
                    objDesignation.Designation = MP.Designation.ToUpper();
                    objDesignation.ModifiedDate = DateTime.Now;
                    objDesignation.DesignationID = MP.DesignationID;
                    db.SaveChanges();
                    msg = "Designation Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object GetDepartmentList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewDepartmentList> GetDepartment = null;

                if (status == 0)
                {
                    GetDepartment = db.ViewDepartmentLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetDepartment = db.ViewDepartmentLists.Where(r => r.Status == 1).ToList();

                }

                if (GetDepartment == null)
                {
                    return new Error { IsError = true, Message = "Department Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetDepartment };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }


        public object GetDesignationList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewDesignationList> GetDesignation = null;

                if (status == 0)
                {
                    GetDesignation = db.ViewDesignationLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetDesignation = db.ViewDesignationLists.Where(r => r.Status == 1).ToList();

                }

                if (GetDesignation == null)
                {
                    return new Error { IsError = true, Message = "Designation Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetDesignation };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleDepartment(DepartmentParam objgr)
        {
            try
            {
                var SingleDepartmentlist = db.ViewDepartmentLists.Where(r => r.DepartmentID == objgr.DepartmentID).FirstOrDefault();
                return SingleDepartmentlist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleDesignation(DesignationParam objgr)
        {
            try
            {
                var SingleDesignationlist = db.ViewDesignationLists.Where(r => r.DesignationID == objgr.DesignationID).FirstOrDefault();
                return SingleDesignationlist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object DeleteDepartment(DepartmentParam MP)
        {
            try
            {
                Tbl_Department_Master objdepartment = db.Tbl_Department_Master.Where(r => r.DepartmentID == MP.DepartmentID).FirstOrDefault();

                if (objdepartment.Status == 1)
                {
                    objdepartment.Status = 0;
                }
                else
                {
                    objdepartment.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Department Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteDesignation(DesignationParam MP)
        {
            try
            {
                Tbl_Designation_Master objdesignation = db.Tbl_Designation_Master.Where(r => r.DesignationID == MP.DesignationID).FirstOrDefault();

                if (objdesignation.Status == 1)
                {
                    objdesignation.Status = 0;
                }
                else
                {
                    objdesignation.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Designation Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}
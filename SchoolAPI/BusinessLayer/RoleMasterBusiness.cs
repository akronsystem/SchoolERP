using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class RoleMasterBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveRole(RoleMasterParam b)
        {
            if (b.Role == null)
            {
                return new Error() { IsError = true, Message = "Required Role" };
            }
            var data = db.Tbl_Role_Master.FirstOrDefault(r => r.Role == b.Role);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Role_Master obj = new Tbl_Role_Master();
                obj.Role = b.Role;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Role_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Role" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object RoleUpdate(RoleMasterUpdateParam b)
        {
            if (b.Role == null)
            {
                return new Error() { IsError = true, Message = "Required Role" };
            }
            var Info = db.Tbl_Role_Master.Where(r => r.Role == b.Role).FirstOrDefault();
            if(Info==null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_Role_Master.Where(r => r.RoleID == b.RoleID).FirstOrDefault();
            try
            {
                Tbl_Role_Master obj = new Tbl_Role_Master();
                data.Role = b.Role;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Role" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetRole(UserCredential obj)
        {
            try
            {
                List<ViewRoleList> Role = null;

                if (obj.Status == "0")
                {
                    Role = db.ViewRoleLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Role = db.ViewRoleLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Role = db.ViewRoleLists.Where(r => r.Status == 1).ToList();

                }

                if (Role == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Role;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleRole(RoleMasterUpdateParam b)
        {
            try
            {
                var Role = db.ViewRoleLists.Where(r => r.RoleID == b.RoleID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = Role };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteRole(RoleMasterUpdateParam PM)
        {
            try
            {
                Tbl_Role_Master obj = db.Tbl_Role_Master.Where(r => r.RoleID == PM.RoleID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Role Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}
using SchoolAPI.BusinessLayer;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.API
{
    public class DepartmentController : ApiController
    {
        [HttpPost]
        public object GetDepartmentMaster([FromBody]DepartmentParam objid)
        {
            try
            {
                var status = objid.Status;
                DepartmentBL obj = new DepartmentBL();
                var ERPDepartment = obj.GetDepartmentList(status);
                return ERPDepartment;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        [HttpPost]
        public object GetDesignationMaster([FromBody]DesignationParam objid)
        {
            try
            {
                var status = objid.Status;
                DepartmentBL obj = new DepartmentBL();
                var ERPDesignation = obj.GetDesignationList(status);
                return ERPDesignation;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object GetSingleDepartmentInfo([FromBody]DepartmentParam OBJGR)
        {
            try
            {
                DepartmentBL obj = new DepartmentBL();
                var SingleGR = obj.GetSingleDepartment(OBJGR);
                return SingleGR;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object GetSingleDesignationInfo([FromBody]DesignationParam OBJGR)
        {
            try
            {
                DepartmentBL obj = new DepartmentBL();
                var SingleGR = obj.GetSingleDesignation(OBJGR);
                return SingleGR;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object SaveDepartment([FromBody] DepartmentParam PR)
        {
            try
            {
                DepartmentBL OBJSAVE = new DepartmentBL();
                var result = OBJSAVE.SaveDepartment(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        public object SaveDesignation([FromBody] DesignationParam PR)
        {
            try
            {
                DepartmentBL OBJSAVE = new DepartmentBL();
                 var result = OBJSAVE.SaveDesignation(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object DeleteDepartment([FromBody] DepartmentParam MP)
        {
            try
            {
                DepartmentBL obj = new DepartmentBL();
                var result = obj.DeleteDepartment(MP);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object DeleteDesignation([FromBody] DesignationParam MP)
        {
            try
            {
                DepartmentBL obj = new DepartmentBL();
                var result = obj.DeleteDesignation(MP);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
    }
}

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
    public class EmployeeMasterController : ApiController
    {
        [HttpPost]
        public object AddEmployee()
        {
            try
            {
                EmployeeMasterParam obj = new EmployeeMasterParam();
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveEmployee(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object AddAddressDetails([FromBody]EmployeeAddressParam obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveEmployeeAddress(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object AddBankDetails([FromBody]EmployeeBankParam obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveEmployeeBank(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object AddAppointmentDetails([FromBody]EmployeeAppointmentParam obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveEmployeeAppointment(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object AddEducationDetails([FromBody]List<EmployeeEducationParam> obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveEmployeeEducation(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object AddUploadDetails()
        {
            try
            {
                EmployeeAttachedDocumentParam obj = new EmployeeAttachedDocumentParam();
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveUploadDocuments(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        public object AddExperienceDetails([FromBody]List<EmployeeExprienceParam> obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.SaveExperienceEducation(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }

        [HttpPost]
        public object GetEmployeeType([FromBody]UserCredential uc)
        {
            try
            {
                EmployeeBusiness obj = new EmployeeBusiness();
                var ERPDepartment = obj.GetDepartmentList(uc);
                return ERPDepartment;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object GetSection([FromBody]UserCredential uc)
        {
            try
            {
                EmployeeBusiness obj = new EmployeeBusiness();
                var data = obj.GetSectionList(uc);
                return data;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object GetStateUnderTaluka([FromBody] TalukaParam d)
        {
            try
            {
                EmployeeBusiness state = new EmployeeBusiness();
                var Result = state.GetStateunderTaluka(d);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetDesignation([FromBody]UserCredential s)
        {
            try
            {
                EmployeeBusiness obj = new EmployeeBusiness();
                var data = obj.GetDesignationList(s);
                return data;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object GetStateDistrictUnderTaluka([FromBody] TalukaParam d)
        {
            try
            {
                EmployeeBusiness state = new EmployeeBusiness();
                var Result = state.GetTaluka(d);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetCategoryList([FromBody]CasteParam objid)
        {
            try
            {

                EmployeeBusiness obj = new EmployeeBusiness();
                var ERPCategory = obj.GetCategoryList(objid);
                return ERPCategory;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object GetReligionList([FromBody]CasteParam objid)
        {
            try
            {

                EmployeeBusiness obj = new EmployeeBusiness();
                var ERPCategory = obj.GetReligionList(objid);
                return ERPCategory;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object GetEmployeeInfo(UserCredential uc)
        {
            try
            {
                EmployeeBusiness board = new EmployeeBusiness();
                var Result = board.GetEmployee(uc);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetSingleEmployee(EmployeeMasterParam obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeInfo(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object GetSingleExperienceDetails(EmployeeMasterParam obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeExperience(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }

        [HttpPost]
        public object GetSingleEducationDetails(EmployeeMasterParam obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeEducation(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object GetSingleDucumentDetails(EmployeeMasterParam obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeDocument(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object GetSingleDucumentDetailsUpdate(EmployeeAttachedDocumentUpdate obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeDocumentUpdate(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object GetSinglEducationDetailsUpdate(EmployeeEducationUpdate obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeEducationsUpdate(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateEmployee()
        {
            try
            {
                EmployeeMasterParam obj = new EmployeeMasterParam();
                EmployeeBusiness update = new EmployeeBusiness();
                var result = update.UpdateEmployee(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateEmployeeAddressDetails([FromBody]EmployeeAddressParam obj)
        {
            try
            {
             
                EmployeeBusiness update = new EmployeeBusiness();
                var result = update.UpdateEmployeeAddress(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateEducationDetails([FromBody]List<EmployeeEducationParam> obj)
        {
         
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.UpdateEmployeeEducation(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateAppointmentDetails([FromBody]EmployeeAppointmentParam obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.UpdateEmployeeAppointment(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateBankDetails([FromBody]EmployeeBankParam obj)
        {
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.UpdateEmployeeBank(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateExperienceDetails([FromBody]List<EmployeeExprienceUpadate> obj)
        {
            
            try
            {
                EmployeeBusiness save = new EmployeeBusiness();
                var result = save.UpdateExperienceEducation(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object GetSinglExperianceDetailsUpdate(EmployeeExprienceUpadate obj)
        {
            try
            {
                EmployeeBusiness getinfo = new EmployeeBusiness();
                var result = getinfo.GetEmployeeExperienceUpdate(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object DeleteEmployee([FromBody]EmplyeeMasterUpadateParam PR)
        {
            try
            {
                EmployeeBusiness Objdelete = new EmployeeBusiness();
                var result = Objdelete.Delete(PR);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }

}

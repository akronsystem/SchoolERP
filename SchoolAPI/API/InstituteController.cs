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
    public class InstituteController : ApiController
    {
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
        public object GetBoard([FromBody]UserCredential uc)
        {
            try
            {
                InstituteBusiness obj = new InstituteBusiness();
                var data = obj.GetBoard(uc);
                return data;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object AddInstitute([FromBody]InstituteParam obj)
        {
            try
            {                
                InstituteBusiness save = new InstituteBusiness();
                var result = save.SaveInstitute(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object AddInstituteAddress([FromBody]InstituteAddressDetailsParam obj)
        {
            try
            {
                InstituteBusiness save = new InstituteBusiness();
                var result = save.SaveAddressInstitute(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object AddInstituteBank([FromBody]InstituteBankParam obj)
        {
            try
            {
                InstituteBusiness save = new InstituteBusiness();
                var result = save.SaveBankInstitute(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object AddInstituteLogo()
        {
            try
            {
                InstituteLogoParam obj = new InstituteLogoParam();
                InstituteBusiness save = new InstituteBusiness();
                var result = save.SaveLogoInstitute();
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetInstituteInfo(UserCredential uc)
        {
            try
            {
                InstituteBusiness board = new InstituteBusiness();
                var Result = board.GetInstitute(uc);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetSingleInstitute(InstituteUpdateParam obj)
        {
            try
            {
                InstituteBusiness getinfo = new InstituteBusiness();
                var result = getinfo.GetInstituteInfo(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateInstitute(InstituteUpdateParam obj)
        {
            try
            {
                InstituteBusiness update = new InstituteBusiness();
                var result = update.UpdateInstitute(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateInstituteAddress(InstituteAdressUpdateParam obj)
        {
            try
            {
                InstituteBusiness update = new InstituteBusiness();
                var result = update.UpdateInstituteAddress(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateInstituteBank(InstituteBankUpdateParam obj)
        {
            try
            {
                InstituteBusiness update = new InstituteBusiness();
                var result = update.UpdateInstituteBank(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object UpdateInstituteLogo()
        {
            try
            {
                InstituteLogoUpdateParam obj = new InstituteLogoUpdateParam();
                InstituteBusiness update = new InstituteBusiness();
                var result = update.UpdateInstituteLogo(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }
        [HttpPost]
        public object DeleteInstitute([FromBody]InstituteUpdateParam PR)
        {
            try
            {
                InstituteBusiness Objdelete = new InstituteBusiness();
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

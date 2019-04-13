using SchoolAPI.BusinessLayer;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using SchoolAPI.Param.SchoolAPI.Param;

namespace SchoolAPI.API
{
    public class ModuleController : ApiController
    {
        [HttpPost] 
        public object SaveUpdate([FromBody] ModuleParam PM)
        {
            try
            {
                ModuleMasterBL MB = new ModuleMasterBL();
                var Result = MB.SaveMenu(PM);
                return Result;
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

       

        [HttpPost]
        public object DeleteMenu([FromBody] ModuleParam PM)
        {
            try
            {
                ModuleMasterBL MB = new ModuleMasterBL();
                var Result = MB.DeleteMenu(PM);
                return Result; 
            }
			catch (Exception e)
			{
				return new Error() { IsError = true, Message = e.Message };
			}
		}
        
        public object SaveModule([FromBody] ModuleParam PR)
        {
            try
            {
                CreateModuleBL OBJSAVE = new CreateModuleBL();
                var result = OBJSAVE.SaveModule(PR);
                return result; 
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message }; 
            }
        }

        [HttpPost]
        public object GetAllMenu(UserCredential UC)
        {
            try
            {
                ModuleMasterBL obj = new ModuleMasterBL();
                var result = obj.GetAllMenus(UC);
                return result;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

       

         [HttpPost]
        public object GetMenuModuleName()
        {
            try
            {
                ModuleMasterBL obj = new ModuleMasterBL();
                var result = obj.GetModuleNames();
                return result; 

            }
			catch (Exception e)
			{
				return new Error() { IsError = true, Message = e.Message };
			}
		}
        [HttpPost]
        //public object GetModuleMaster([FromBody]ModuleParam objid)

        public object GetModuleMaster([FromBody]ModuleParam objid)
        {
            try
            {
                var status = objid.Status;
                CreateModuleBL obj = new CreateModuleBL();
                var ERPModule = obj.GetModuleList(status);
                return ERPModule; 
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

		[HttpPost]
		public object GetChildMenuNames()
		{
			try
			{
				ModuleMasterBL obj = new ModuleMasterBL();
				var result = obj.GetChildMenu();
				return result;
			}
			catch (Exception e)
			{
				return new Error() { IsError = true, Message = e.Message };
			}
		}

		[HttpPost]
		public object GetSingleModuleInfo([FromBody]ModuleParam OBJGR)
        {
            try
            {
                CreateModuleBL obj = new CreateModuleBL();
                var SingleGR = obj.GetSingleModule(OBJGR);
                return SingleGR; 
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        } 
        
        [HttpPost]
        public object GetMenuUnderModule([FromBody] ModuleParam P)
        {
            try
            {
                ModuleMasterBL obj = new ModuleMasterBL();
                var result = obj.GetModuleWiseMenu(P);
                return result;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        [HttpPost]
        public object GetSingleMenu([FromBody]ModuleParam MP)
        {
            try
            {
                ModuleMasterBL obj = new ModuleMasterBL();
                var result = obj.GetSingleMenuBL(MP);
                return result;
            }
            catch(Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };

            }

        }

        [HttpPost]
        public object GetChildMenuName([FromBody]ModuleParam M)
        {
            try
            {
                ModuleMasterBL obj = new ModuleMasterBL();
                var result = obj.GetMenuNames(M);
                return result;
            }
            catch(Exception e) 
             {
                return new Error() { IsError = true, Message = e.Message };

            }
        }

        [HttpPost]
        public object DeleteModule([FromBody] ModuleParam MP)
        {
            try
            {
                CreateModuleBL obj = new CreateModuleBL();
                var result = obj.DeleteModule(MP);
                return result;
            }
            catch (Exception e) 
            {
                return new Error() { IsError = true, Message = e.Message };

            } 
        } 
 

    }
}

using SchoolAPI.BusinessLayer;
using SchoolAPI.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.API
{
    public class AssignWidgetController : ApiController
    {
        AssignWidgetBL Bobj = new AssignWidgetBL();
        [HttpPost]
        public object GetWidgetList(UserCredential uc)
        {
            var result = Bobj.GetWidgetList(uc);
            return result;
        }
        [HttpPost]
        public object GetRole()
        { 
            var result = Bobj.GetRole();
            return result;
        }

        [HttpPost]
          public object GetAssignWidget(UserCredential uc)
          {
            var result = Bobj.GetAssignWidget(uc);
            return result;
          }
       
        [HttpPost]
        public object SaveAssignWidget([FromBody]AssignWidgetParam Pobj)
        {
            var result = Bobj.SaveAssignWidget(Pobj);
            return result;
        }

        [HttpPost]
        public object GetAssignWidgetRoleWise([FromBody] AssignWidgetParam Pobj)
        {
            var result = Bobj.GetAssignWidgetRoleWise(Pobj);
            return result;
        }

    }
}

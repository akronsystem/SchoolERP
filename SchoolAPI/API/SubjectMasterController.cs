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
    public class SubjectMasterController : ApiController
    {
        [HttpPost]
        public object AddSubject([FromBody]SubjectParam Subparam)
        {
            SubjectMasterBussiness Add = new SubjectMasterBussiness();
            var result = Add.SaveSubject(Subparam);
            return result;
        }
        [HttpPost]
        public object GetSingleSubject([FromBody] SubjectParam Subparam)
        {
            SubjectMasterBussiness obj = new SubjectMasterBussiness();
            var result = obj.GetSingleSubject(Subparam);
            return result;
        }
        [HttpPost]
        public object UpdateSingleSubject([FromBody] SubjectParam Subparam)
        {
            SubjectMasterBussiness Update = new SubjectMasterBussiness();
            var result = Update.UpdateSubject(Subparam);
            return result;
        }
        [HttpPost]
        public object DeleteSingleSubject([FromBody] SubjectParam Subparam)
        {
            SubjectMasterBussiness Delete = new SubjectMasterBussiness();
            var result = Delete.DeleteSubject(Subparam);
            return result;
        }
        [HttpPost]
        public object DisplayAllSubject([FromBody] SubjectParam Subparam)
        {
            SubjectMasterBussiness Display = new SubjectMasterBussiness();
            var result = Display.DisplaySubject(Subparam);
            return result;
        }
    }
}

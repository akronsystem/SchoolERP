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
    public class SectionMasterController : ApiController
    {
           [HttpPost]
          public object AddSection([FromBody]SectionParam SectionParam)
          {
            SectionMasterBussiness Add = new SectionMasterBussiness();
           
              var result = Add.SaveSection(SectionParam);
            return result;
          }
        [HttpPost]
        public object DisplaySection([FromBody]SectionParam SectionParam)
        {
            SectionMasterBussiness Display = new SectionMasterBussiness();
          var result=  Display.DisplaySection(SectionParam);
            return result;
        }
        [HttpPost]
        public object GetSingleSection([FromBody]SectionParam SectionParam)
        {
            SectionMasterBussiness Display = new SectionMasterBussiness();


            var result = Display.SingleSection(SectionParam);
            return result;
        }
        [HttpPost]
        public object UpdateSection([FromBody]SectionParam SectionParam)
        {
            SectionMasterBussiness Update = new SectionMasterBussiness();
            var result = Update.UpdateSection(SectionParam);
            return result;
        }
        [HttpPost]
        public object DeleteSection([FromBody]SectionParam SectionParam)
        {
            SectionMasterBussiness Delete = new SectionMasterBussiness();
            var result = Delete.DeleteSection(SectionParam);
            return result;

        }
    }
}

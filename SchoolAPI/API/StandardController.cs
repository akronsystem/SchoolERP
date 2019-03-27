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
    public class StandardController : ApiController
    {
        [HttpPost]
        public object SaveStandard([FromBody] StandardParam StdParam)
        {
            StandardMaster Save = new StandardMaster();
           
            var result = Save.AddStandard(StdParam);
            return result;
        }

        [HttpPost]
        public object DisplayStandard([FromBody] StandardParam StdParam)
         {
            StandardMaster Save = new StandardMaster();

            var result = Save.GetStandardInfo(StdParam);
            return result;
        }

        [HttpPost]
        public object GetSingleStandard([FromBody] StandardParam StdParam)
        {
            StandardMaster obj = new StandardMaster();

            var result = obj.GetSingleStandard(StdParam);
            return result;
        }

        [HttpPost]
        public object DeleteStandard([FromBody] StandardParam StdParam)
        {
            StandardMaster Delete = new StandardMaster();

            var result = Delete.DeleteStandard(StdParam);
            return result;
        }

        [HttpPost]
        public object UpdateStandard([FromBody] StandardParam StdParam)
        {
            StandardMaster Edit = new StandardMaster();

            var result = Edit.UpdateStandard(StdParam);
            return result;
        }

    }
}

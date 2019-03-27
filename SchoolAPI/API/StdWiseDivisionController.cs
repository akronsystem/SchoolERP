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
    public class StdWiseDivisionController : ApiController
    {
        [HttpPost]
        public object GetAllStandard()
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.GetAllStandard();
            return result;
        }
        [HttpPost]
        public object GetAllBoard()
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.GetBoard();
            return result;

        }
        [HttpPost]
        public object GetAllDivision()
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.GetDivision();
            return result;

        }
        [HttpPost]
        public object AddStdWiseDivision(StdWiseDivParam objParam)
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.SaveStdWiseDiv(objParam);
            return result;
        }
        [HttpPost]
        public object Display_StandardWiseDivision(StdWiseDivParam objParam)
        {

            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.DisplayStdWiseDiv(objParam);
            return result;
        }
        [HttpPost]
        public object GetSingleValue(StdWiseDivParam objParam)
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.GetSingleStdWiseDiv(objParam);
            return result;

        }
        [HttpPost]
        public object UpdateStdDiv(StdWiseDivParam objParam)
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.UpdateStdDiv(objParam);
            return result;

        }
        [HttpPost]
        public object DeleteSingleStdDivision(StdWiseDivParam objParam)
        {
            StdWiseDivBussiness obj = new StdWiseDivBussiness();
            var result = obj.DeleteSingleStdDivision(objParam);
            return result;
        }

    }
}

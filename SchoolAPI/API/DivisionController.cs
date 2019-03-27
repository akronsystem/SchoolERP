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
    public class DivisionController : ApiController
    {

        [HttpPost]
        public object AddDivision([FromBody]DivisionParam DivParam)
        {
            DivisionMaster Add = new DivisionMaster();
             var Result= Add.SaveDivision(DivParam);
            return Result;
        }
        [HttpPost]
        public object DisplayDivision([FromBody]DivisionParam DivParam)
        {
            DivisionMaster ObjDisplay = new DivisionMaster();
            var result = ObjDisplay.DisplayDiv(DivParam);


            return result;
        }
        [HttpPost]
        public object GetSingleDivision([FromBody]DivisionParam DivParam)
        {

            DivisionMaster SingleVale = new DivisionMaster();
            var result=  SingleVale.GetSingleDivision(DivParam);
            return result;
        }
        [HttpPost]
        public object UpdateDivision([FromBody]DivisionParam DivParam)
        {
            DivisionMaster SingleVale = new DivisionMaster();
            var result = SingleVale.UpdateDivision(DivParam);
            return result;
        }
        [HttpPost]
        public object DeleteDivision([FromBody]DivisionParam DivParam)
        {
            DivisionMaster SingleVale = new DivisionMaster();
            var result = SingleVale.DeleteDivision(DivParam);
            return result;
         
        }

    }
}

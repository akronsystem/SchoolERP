using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class SubjectParam
    {
        public Int32 SubjectId
        {
            get;set;
        }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int Status { get; set; }
    }
}
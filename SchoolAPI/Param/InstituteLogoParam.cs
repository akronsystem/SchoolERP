using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class InstituteLogoParam
    {
        //public long LogoDid { get; set; }

        public long InstituteId { get; set; }

        public string LogoName { get; set; }

        public string HeaderName { get; set; }

        public long CreatedId { get; set; }

        public DateTime CreatedOn { get; set; }

        public long ModifiedId { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
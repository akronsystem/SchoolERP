﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class UpdateAcademicYear
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AcademicID { get; set; }
        public string Type { get; set; }
        public string AcademicYear { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
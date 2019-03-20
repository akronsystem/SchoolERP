using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeEducationParam
    {
       // public long EducationID { get; set; }

        public long EmployeeID { get; set; }

        public string CourseName { get; set; }

        public string PassingMothYear { get; set; }

        public string SchoolCollege { get; set; }

        public string UniversityBoard { get; set; }

        public string BoardDivisionState { get; set; }

        public decimal CreditPercentageSGPA { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
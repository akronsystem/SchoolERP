using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeExprienceUpadate
    {
        public long ExprienceID { get; set; }

        public long EmployeeID { get; set; }

        public long ExprienceTypeID { get; set; }

        public string DocumentType { get; set; }

        public string Organization { get; set; }

        public string OrganizationAddress { get; set; }

        public string Designation { get; set; }

        public DateTime PeriodFrom { get; set; }

        public DateTime PeriodTo { get; set; }

        public int TotalExprience { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeBankParam
    {
       // public long BankID { get; set; }

        public long EmployeeID { get; set; }

        public string BankName { get; set; }

        public string AccountNumber { get; set; }

        public string BranchName { get; set; }

        public string IFSCCode { get; set; }

        public string MICRCode { get; set; }

        public string UAN { get; set; }

        public string PF { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class InstituteBankUpdateParam
    {
        public long InstituteBankDid { get; set; }

        public long InstituteId { get; set; }

        public long IndexNo { get; set; }

        public string PanNo { get; set; }

        public string TanNo { get; set; }

        public string Gstin { get; set; }

        public string BankName { get; set; }

        public string Ifsc { get; set; }

        public string Micr { get; set; }

        public long AccountNumber { get; set; }

        public int Status { get; set; }

        public long CreatedId { get; set; }

        public DateTime CreatedOn { get; set; }

        public long ModifiedId { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
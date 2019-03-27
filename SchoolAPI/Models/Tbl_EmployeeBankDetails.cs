namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeBankDetails
    {
        [Key]
        public long BankID { get; set; }

        public long? EmployeeID { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        [StringLength(100)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string IFSCCode { get; set; }

        [StringLength(100)]
        public string MICRCode { get; set; }

        [StringLength(50)]
        public string UAN { get; set; }

        [StringLength(50)]
        public string PF { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        public virtual Tbl_EmployeeMaster Tbl_EmployeeMaster { get; set; }
    }
}

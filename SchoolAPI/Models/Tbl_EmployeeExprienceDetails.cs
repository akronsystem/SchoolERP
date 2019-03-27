namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeExprienceDetails
    {
        [Key]
        public long ExprienceID { get; set; }

        public long? EmployeeID { get; set; }

        public long? ExprienceTypeID { get; set; }

        [StringLength(50)]
        public string ExperienceDocumentType { get; set; }

        [StringLength(50)]
        public string Organization { get; set; }

        [StringLength(200)]
        public string OrganizationAddress { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        public DateTime? PeriodFrom { get; set; }

        public DateTime? PeriodTo { get; set; }

        public int? TotalExprience { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        public virtual Tbl_EmployeeMaster Tbl_EmployeeMaster { get; set; }
    }
}

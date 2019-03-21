namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeEducationDetails
    {
        [Key]
        public long EducationID { get; set; }

        public long? EmployeeID { get; set; }

        [StringLength(50)]
        public string CourseName { get; set; }

        [StringLength(20)]
        public string PassingMothYear { get; set; }

        [StringLength(50)]
        public string SchoolCollege { get; set; }

        [StringLength(50)]
        public string UniversityBoard { get; set; }

        [StringLength(50)]
        public string BoardDivisionState { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CreditPercentageSGPA { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        //public virtual Tbl_EmployeeMaster Tbl_EmployeeMaster { get; set; }
    }
}

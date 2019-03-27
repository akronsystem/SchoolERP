namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeMaster
    {
        [Key]
        public long EmployeeID { get; set; }

        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int? EmployeeCode { get; set; }

        public long? SectionID { get; set; }

        public long? DepartmentID { get; set; }

        public long? DesignationID { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MobileNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AlternateMobileNo { get; set; }

        [StringLength(100)]
        public string EmailID { get; set; }

        [StringLength(100)]
        public string AlternateEmailID { get; set; }

        [StringLength(5)]
        public string BloodGroup { get; set; }

        public long? ReligionID { get; set; }

        public long? CategoryID { get; set; }

        public long? CasteID { get; set; }

        public long? SubCasteID { get; set; }

        public DateTime? DateofBirth { get; set; }

        public long? ShiftID { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }

        [StringLength(500)]
        public string Sign { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }
    }
}

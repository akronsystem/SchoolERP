namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewEmployeeEducationList")]
    public partial class ViewEmployeeEducationList
    {
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

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        public int? Status { get; set; }

        public int? EmployeeCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EducationID { get; set; }

        public long? Expr1 { get; set; }

        public int? Expr2 { get; set; }
    }
}

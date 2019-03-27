namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewEmployeeExperienceList")]
    public partial class ViewEmployeeExperienceList
    {
        public long? ExprienceTypeID { get; set; }

        [StringLength(50)]
        public string ExperienceDocumentType { get; set; }

        [StringLength(50)]
        public string Organization { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string OrganizationAddress { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        public DateTime? PeriodFrom { get; set; }

        public DateTime? PeriodTo { get; set; }

        public int? TotalExprience { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string ExprienceType { get; set; }

        public int? EmployeeCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ExprienceID { get; set; }

        public int? Expr1 { get; set; }
    }
}

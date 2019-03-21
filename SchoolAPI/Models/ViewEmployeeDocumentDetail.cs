namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ViewEmployeeDocumentDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Path { get; set; }

        [StringLength(100)]
        public string DocumentType { get; set; }

        public int? EmployeeCode { get; set; }

        public long? Expr1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AttachmentID { get; set; }
    }
}

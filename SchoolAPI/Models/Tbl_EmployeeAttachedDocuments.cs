namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeAttachedDocuments
    {
        [Key]
        public long AttachmentID { get; set; }

        public long? EmployeeID { get; set; }

        [StringLength(100)]
        public string DocumentType { get; set; }

        [StringLength(50)]
        public string Path { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }
    }
}

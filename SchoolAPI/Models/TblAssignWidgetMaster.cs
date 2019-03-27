namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblAssignWidgetMaster")]
    public partial class TblAssignWidgetMaster
    {
        [Key]
        public long AssignWidgetID { get; set; }

        [StringLength(50)]
        public string RoleID { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }
    }
}

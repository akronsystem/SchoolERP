namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewAssignWidget")]
    public partial class ViewAssignWidget
    {
        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string WidgetName { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        public int? Sequence { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RoleID { get; set; }

        public int? Status { get; set; }

        public long? AssignWidgetID { get; set; }
    }
}

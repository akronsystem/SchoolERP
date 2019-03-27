namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewGetAssignWidgetRoleWise")]
    public partial class ViewGetAssignWidgetRoleWise
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RoleID { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public long? WidgetID { get; set; }

        public int? Sequence { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AssignWidgetID { get; set; }
    }
}

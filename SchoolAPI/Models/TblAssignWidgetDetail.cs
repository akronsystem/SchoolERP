namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblAssignWidgetDetail
    {
        [Key]
        public long AssignWidgetDID { get; set; }

        public long? AssignWidgetID { get; set; }

        public long? WidgetID { get; set; }

        public int? Sequence { get; set; }
    }
}

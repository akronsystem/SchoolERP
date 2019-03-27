namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewWidgetList")]
    public partial class ViewWidgetList
    {
        [Key]
        public long WidgetID { get; set; }

        [StringLength(50)]
        public string WidgetName { get; set; }

        public int? Status { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }
    }
}

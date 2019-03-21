namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Display_Board
    {
        [Key]
        [Column(Order = 0)]
        public long BoardID { get; set; }

        [StringLength(20)]
        public string BoardName { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string Display { get; set; }
    }
}

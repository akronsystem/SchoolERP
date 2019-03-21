namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewBoardList")]
    public partial class ViewBoardList
    {
        public int? Status { get; set; }

        [Key]
        public long BoardID { get; set; }

        [StringLength(20)]
        public string BoardName { get; set; }
    }
}

namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewCategoryReligionCaste")]
    public partial class ViewCategoryReligionCaste
    {
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string ReligionName { get; set; }

        [StringLength(50)]
        public string CasteName { get; set; }

        [StringLength(50)]
        public string SubCasteName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CasteID { get; set; }

        public long? ReligionID { get; set; }

        public long? CategoryID { get; set; }

        public long? SubCasteID { get; set; }

        public int? Status { get; set; }
    }
}

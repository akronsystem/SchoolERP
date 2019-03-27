namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Display_StandardWiseDivision
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StdWiseDivisionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BoardID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DivisionID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StandardID { get; set; }

        public int? Status { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(5)]
        public string Display { get; set; }

        [StringLength(20)]
        public string BoardName { get; set; }

        [StringLength(10)]
        public string StandardName { get; set; }

        [StringLength(10)]
        public string DivisionName { get; set; }
    }
}

namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Institute_Logo_Details
    {
        [Key]
        public long LogoDid { get; set; }

        public long? InstituteId { get; set; }

        [StringLength(100)]
        public string LogoName { get; set; }

        [StringLength(100)]
        public string HeaderName { get; set; }

        public long? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedId { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

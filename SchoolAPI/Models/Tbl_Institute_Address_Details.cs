namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Institute_Address_Details
    {
        [Key]
        public long InstituteDid { get; set; }

        public long? InstituteId { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public long? StateId { get; set; }

        [StringLength(50)]
        public string Pincode { get; set; }

        [StringLength(15)]
        public string LandlineNumber { get; set; }

        [StringLength(15)]
        public string PhoneNumber1 { get; set; }

        [StringLength(15)]
        public string PhoneNumber2 { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string InstituteEmail { get; set; }

        [StringLength(100)]
        public string PrinciaplEmail { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public int? Status { get; set; }

        public long? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedId { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

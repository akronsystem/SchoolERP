namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Institute_Master
    {
        [Key]
        public long InstituteId { get; set; }

        public long? SectionId { get; set; }

        public long? UdiseNo { get; set; }

        [StringLength(100)]
        public string InstituteName { get; set; }

        public long? BoardId { get; set; }

        public long? AffilationNo { get; set; }

        public DateTime? EstablishedYear { get; set; }

        [StringLength(100)]
        public string InstituteOrganizationName { get; set; }

        [StringLength(100)]
        public string OrganizationAddress { get; set; }

        [StringLength(100)]
        public string OrganizationRegistrationNo { get; set; }

        public int? Status { get; set; }

        public long? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedId { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

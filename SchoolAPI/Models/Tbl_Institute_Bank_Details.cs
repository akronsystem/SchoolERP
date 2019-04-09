namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Institute_Bank_Details
    {
        [Key]
        public long InstituteBankDid { get; set; }

        public long? InstituteId { get; set; }

        public long? IndexNo { get; set; }

        [StringLength(50)]
        public string PanNo { get; set; }

        [StringLength(50)]
        public string TanNo { get; set; }

        [StringLength(50)]
        public string Gstin { get; set; }

        [StringLength(200)]
        public string BankName { get; set; }

        [StringLength(20)]
        public string Ifsc { get; set; }

        [StringLength(20)]
        public string Micr { get; set; }

        public long? AccountNumber { get; set; }

        public int? Status { get; set; }

        public long? CreatedId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedId { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

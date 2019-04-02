namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_InstituteList
    {
        public long? UdiseNo { get; set; }

        public long? SectionId { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InstituteId { get; set; }

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

        [StringLength(100)]
        public string LogoName { get; set; }

        [StringLength(100)]
        public string HeaderName { get; set; }

        public long? Expr1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LogoDid { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InstituteBankDid { get; set; }

        public long? Expr2 { get; set; }

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

        [StringLength(200)]
        public string Address1 { get; set; }

        public long? Expr3 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InstituteDid { get; set; }

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
    }
}

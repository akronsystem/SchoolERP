namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeAddressDetails
    {
        [Key]
        public long AddressID { get; set; }

        public long? EmployeeID { get; set; }

        [StringLength(200)]
        public string PermanentAddress { get; set; }

        public long? PermanantStateID { get; set; }

        public long? PermanantDistrictID { get; set; }

        public long? PermanantTalukaID { get; set; }

        [StringLength(10)]
        public string PermanantPincode { get; set; }

        [StringLength(100)]
        public string PermanentCountry { get; set; }

        [StringLength(200)]
        public string CorrespondanceAddress { get; set; }

        public long? CorrespondanceStateID { get; set; }

        public long? CorrespondanceDistrictID { get; set; }

        public long? CorrespondanceTalukaID { get; set; }

        [StringLength(10)]
        public string CorrespondancePincode { get; set; }

        [StringLength(100)]
        public string CorrespondanceCountry { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        //public virtual Tbl_EmployeeAddressDetails Tbl_EmployeeAddressDetails1 { get; set; }

        //public virtual Tbl_EmployeeAddressDetails Tbl_EmployeeAddressDetails2 { get; set; }

        public virtual Tbl_EmployeeMaster Tbl_EmployeeMaster { get; set; }
    }
}

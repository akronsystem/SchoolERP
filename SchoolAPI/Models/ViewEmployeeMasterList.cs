namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewEmployeeMasterList")]
    public partial class ViewEmployeeMasterList
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmployeeID { get; set; }

        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int? EmployeeCode { get; set; }

        public long? SectionID { get; set; }

        public long? DepartmentID { get; set; }

        public long? DesignationID { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MobileNo { get; set; }

        [StringLength(200)]
        public string PermanentAddress { get; set; }

        public long? PermanantStateID { get; set; }

        public long? PermanantDistrictID { get; set; }

        [StringLength(20)]
        public string SectionName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AlternateMobileNo { get; set; }

        [StringLength(100)]
        public string EmailID { get; set; }

        [StringLength(100)]
        public string AlternateEmailID { get; set; }

        [StringLength(5)]
        public string BloodGroup { get; set; }

        public long? ReligionID { get; set; }

        public long? CategoryID { get; set; }

        public long? CasteID { get; set; }

        public long? SubCasteID { get; set; }

        public DateTime? DateofBirth { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }

        [StringLength(500)]
        public string Sign { get; set; }

        [StringLength(50)]
        public string ShiftName { get; set; }

        [StringLength(50)]
        public string ReligionName { get; set; }

        [StringLength(50)]
        public string CasteName { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public long? ShiftID { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        [StringLength(100)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string IFSCCode { get; set; }

        [StringLength(100)]
        public string MICRCode { get; set; }

        [StringLength(50)]
        public string UAN { get; set; }

        [StringLength(50)]
        public string PF { get; set; }

        [StringLength(20)]
        public string JobType { get; set; }

        [StringLength(50)]
        public string AppointmentType { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(5)]
        public string SrGradeScaleApplicable { get; set; }

        public DateTime? SrGradeScaleApplicableDate { get; set; }

        [StringLength(5)]
        public string SelectionGradeScaleApplicable { get; set; }

        public DateTime? SelectionGradeScaleApplicableDate { get; set; }

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

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DistrictID { get; set; }

        public long? StateID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TalukaID { get; set; }

        [StringLength(50)]
        public string Taluka { get; set; }

        public long? Expr1 { get; set; }

        [StringLength(50)]
        public string Expr2 { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Expr3 { get; set; }

        public long? ExprienceTypeID { get; set; }

        [StringLength(50)]
        public string ExprienceType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeMasterParam
    {
        public int EmployeeCode { get; set; }      
        public string EmployeeName { get; set; }

        public long EmployeeTypeID { get; set; }

        public long SectionID { get; set; }

        public long DepartmentID { get; set; }

        public long DesignationID { get; set; }
        
        public string Gender { get; set; }
        
        public decimal MobileNo { get; set; }
        
        public decimal AlternateMobileNo { get; set; }
        
        public string EmailID { get; set; }
        
        public string AlternateEmailID { get; set; }
        
        public string BloodGroup { get; set; }

        public long ReligionID { get; set; }

        public long CategoryID { get; set; }

        public long CasteID { get; set; }

        public long SubCasteID { get; set; }

        public DateTime DateofBirth { get; set; }

        public long ShiftID { get; set; }        
      
        
        public string ImagePath { get; set; }
        
        public string Sign { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }


        //Address Param
        //public long EmployeeID { get; set; }

        //public string PermanentAddress { get; set; }

        //public long PermanantStateID { get; set; }

        //public long PermanantDistrictID { get; set; }

        //public long PermanantTalukaID { get; set; }

        //public string PermanantPincode { get; set; }

        //public string PermanentCountry { get; set; }

        //public string CorrespondanceAddress { get; set; }

        //public long CorrespondanceStateID { get; set; }

        //public long CorrespondanceDistrictID { get; set; }

        //public long CorrespondanceTalukaID { get; set; }

        //public string CorrespondancePincode { get; set; }

        //public string CorrespondanceCountry { get; set; }

        ////Bank Param
        //public string BankName { get; set; }

        //public string AccountNumber { get; set; }

        //public string BranchName { get; set; }

        //public string IFSCCode { get; set; }

        //public string MICRCode { get; set; }

        //public string UAN { get; set; }

        //public string PF { get; set; }

        ////EducationParam
        //public string CourseName { get; set; }

        //public string PassingMothYear { get; set; }

        //public string SchoolCollege { get; set; }

        //public string UniversityBoard { get; set; }

        //public string BoardDivisionState { get; set; }

        //public decimal CreditPercentageSGPA { get; set; }

        ////ExperianceParam
        //public long ExprienceTypeID { get; set; }

        //public string DocumentType { get; set; }

        //public string Organization { get; set; }

        //public string OrganizationAddress { get; set; }

        //public string Designation { get; set; }

        //public DateTime PeriodFrom { get; set; }

        //public DateTime PeriodTo { get; set; }

        //public int TotalExprience { get; set; }

        ////AttchedDocumentParam
        //public long DocumentID { get; set; }

        //public string ExperienceDocumentType { get; set; }

        //public string Path { get; set; }

        ////Appointment Param
        //public string AppointmentType { get; set; }

        //public string JobType { get; set; }

        //public DateTime JoiningDate { get; set; }

        //public string SrGradeScaleApplicable { get; set; }

        //public DateTime SrGradeScaleApplicableDate { get; set; }

        //public string SelectionGradeScaleApplicable { get; set; }

        //public DateTime SelectionGradeScaleApplicableDate { get; set; }


    }
}
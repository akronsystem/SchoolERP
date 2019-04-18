
namespace SchoolAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SchoolAPI.Models; 

    public partial class SchoolAdminContext : DbContext
    {
        public SchoolAdminContext()
            : base("name=SchoolAdminContext1")
        {
        }
        public virtual DbSet<ViewGetAssignWidgetRoleWise> ViewGetAssignWidgetRoleWises { get; set; }

        public virtual DbSet<TblAssignWidgetDetail> TblAssignWidgetDetails { get; set; }
        public virtual DbSet<TblAssignWidgetMaster> TblAssignWidgetMasters { get; set; }

        public virtual DbSet<ViewAssignWidget> ViewAssignWidgets { get; set; }
        
        public virtual DbSet<ViewSchoolAchievementDetail> ViewSchoolAchievementDetails { get; set; }

        public virtual DbSet<TblSchoolAchievementDetail> TblSchoolAchievementDetails { get; set; }

        public virtual DbSet<TblAchievementTypeMaster> TblAchievementTypeMasters { get; set; }

        public virtual DbSet<ViewAchievementTypeMaster> ViewAchievementTypeMasters { get; set; }

        //public virtual DbSet<Tbl_District> Tbl_District { get; set; }
        //public virtual DbSet<Tbl_State> Tbl_State { get; set; }
        //public virtual DbSet<Tbl_Taluka> Tbl_Taluka { get; set; }
        public virtual DbSet<Tbl_Religion_Master> TblReligionMasters { get; set; }
        public virtual DbSet<ViewReligionList> ViewReligionLists { get; set; }
        public virtual DbSet<Tbl_Category_Master> Tbl_Category_Master { get; set; }
        public virtual DbSet<ViewCategoryList> ViewCategoryLists { get; set; }
        public virtual DbSet<Tbl_Minority_Master> Tbl_Minority_Master { get; set; }
        public virtual DbSet<ViewMinorityList> ViewMinorityLists { get; set; }
        public virtual DbSet<Tbl_Caste_Master> Tbl_Caste_Master { get; set; }
        public virtual DbSet<Tbl_Sub_Caste_Master> Tbl_Sub_Caste_Master { get; set; }
        public virtual DbSet<ViewCasteList> ViewCasteLists { get; set; }
        public virtual DbSet<ViewSubCasteList> ViewSubCasteLists { get; set; }
        public virtual DbSet<Tbl_Department_Master> Tbl_Department_Master { get; set; }
        public virtual DbSet<Tbl_Designation_Master> Tbl_Designation_Master { get; set; }
        public virtual DbSet<ViewDepartmentList> ViewDepartmentLists { get; set; }
        public virtual DbSet<ViewDesignationList> ViewDesignationLists { get; set; }
         public virtual DbSet<Tbl_District> Tbl_District { get; set; }
        public virtual DbSet<Tbl_State> Tbl_State { get; set; }
        public virtual DbSet<Tbl_Taluka> Tbl_Taluka { get; set; }
        public virtual DbSet<ViewDistrictList> ViewDistrictLists { get; set; }
        public virtual DbSet<ViewStateList> ViewStateLists { get; set; }
        public virtual DbSet<ViewTalukaList> ViewTalukaLists { get; set; }
        public virtual DbSet<Tbl_AcademicYear_Master> Tbl_AcademicYear_Master { get; set; }
        public virtual DbSet<ViewAcademicYearList> ViewAcademicYearLists { get; set; }
        public virtual DbSet<Tbl_Term_Master> Tbl_Term_Master { get; set; }
        public virtual DbSet<ViewTermList> ViewTermLists { get; set; }
        public virtual DbSet<Tbl_Unit_Master> Tbl_Unit_Master { get; set; }
        public virtual DbSet<ViewUnitList> ViewUnitLists { get; set; }
        public virtual DbSet<Tbl_Board_Master> Tbl_Board_Master { get; set; }
        public virtual DbSet<Tbl_TermCommencementDate> Tbl_TermCommencementDate { get; set; }
        public virtual DbSet<ViewTermCommencementList> ViewTermCommencementLists { get; set; }
        public virtual DbSet<Tbl_FeeType_Master> Tbl_FeeType_Master { get; set; }
        public virtual DbSet<ViewFeeTypeList> ViewFeeTypeLists { get; set; }
        public virtual DbSet<Tbl_ExprienceType_Master> Tbl_ExprienceType_Master { get; set; }
        public virtual DbSet<ViewExperienceTypeList> ViewExperienceTypeLists { get; set; }
        public virtual DbSet<Tbl_CommitteeType_Master> Tbl_CommitteeType_Master { get; set; }
        public virtual DbSet<ViewCommitteeList> ViewCommitteeLists { get; set; }
        public virtual DbSet<Tbl_CommitteeMaster> Tbl_CommitteeMaster { get; set; }
        public virtual DbSet<ViewCommitteMasterList> ViewCommitteMasterLists { get; set; }
        public virtual DbSet<Tbl_SMTPConfiguration> Tbl_SMTPConfiguration { get; set; }
        public virtual DbSet<ViewSMTPList> ViewSMTPLists { get; set; }
      
        public virtual DbSet<Tbl_Role_Master> Tbl_Role_Master { get; set; }
        public virtual DbSet<ViewRoleList> ViewRoleLists { get; set; }
        public virtual DbSet<Tbl_Shift_Master> Tbl_Shift_Master { get; set; }
        public virtual DbSet<ViewShiftList> ViewShiftLists { get; set; }
        public virtual DbSet<Tbl_Shift_Details> Tbl_Shift_Details { get; set; }
        public virtual DbSet<ViewShiftDetailsList> ViewShiftDetailsLists { get; set; }
        public virtual DbSet<Tbl_EventType_Master> Tbl_EventType_Master { get; set; }
        public virtual DbSet<ViewEventTypeList> ViewEventTypeLists { get; set; }
        public virtual DbSet<Tbl_EventMaster> Tbl_EventMaster { get; set; }
        public virtual DbSet<ViewEventMasterList> ViewEventMasterLists { get; set; }
        public virtual DbSet<Tbl_NotificationType> Tbl_NotificationType { get; set; }
        public virtual DbSet<ViewNotificationTypeList> ViewNotificationTypeLists { get; set; }
        public virtual DbSet<Tbl_EmployeeAddressDetails> Tbl_EmployeeAddressDetails { get; set; }
        public virtual DbSet<Tbl_EmployeeAppointmentDetails> Tbl_EmployeeAppointmentDetails { get; set; }
        public virtual DbSet<Tbl_EmployeeAttachedDocuments> Tbl_EmployeeAttachedDocuments { get; set; }
        public virtual DbSet<Tbl_EmployeeBankDetails> Tbl_EmployeeBankDetails { get; set; }
        public virtual DbSet<Tbl_EmployeeEducationDetails> Tbl_EmployeeEducationDetails { get; set; }
        public virtual DbSet<Tbl_EmployeeExprienceDetails> Tbl_EmployeeExprienceDetails { get; set; }
        public virtual DbSet<Tbl_EmployeeMaster> Tbl_EmployeeMaster { get; set; }
        public virtual DbSet<View_SectionDisplay> View_SectionDisplay { get; set; }
        public virtual DbSet<ViewCategoryReligionCaste> ViewCategoryReligionCastes { get; set; }
        public virtual DbSet<ViewEmployeeMasterList> ViewEmployeeMasterLists { get; set; }
        public virtual DbSet<ViewEmployeeDocumentDetail> ViewEmployeeDocumentDetails { get; set; }
        public virtual DbSet<ViewEmployeeEducationList> ViewEmployeeEducationLists { get; set; }
        public virtual DbSet<ViewEmployeeExperienceList> ViewEmployeeExperienceLists { get; set; }

        //Section
        public virtual DbSet<Tbl_StandardMaster> Tbl_StandardMaster { get; set; }
        public virtual DbSet<ViewDisplayStandard> ViewDisplayStandards { get; set; }
        public virtual DbSet<Tbl_Section_Master> Tbl_Section_Master { get; set; }
        public virtual DbSet<Tbl_Division_Master> Tbl_Division_Master { get; set; }
        public virtual DbSet<View_DisplayDivision> View_DisplayDivision { get; set; }
        //public virtual DbSet<View_SectionDisplay> View_SectionDisplay { get; set; }
        public virtual DbSet<Tbl_Subject_Master> Tbl_Subject_Master { get; set; }
        public virtual DbSet<View_Display_Subject> View_Display_Subject { get; set; }
        public virtual DbSet<View_Display_Board> View_Display_Board { get; set; }
        public virtual DbSet<Tbl_StandardWiseDivision> Tbl_StandardWiseDivision { get; set; }
        public virtual DbSet<View_Display_StandardWiseDivision> View_Display_StandardWiseDivision { get; set; }

        //Institute

        public virtual DbSet<Tbl_Institute_Address_Details> Tbl_Institute_Address_Details { get; set; }
        public virtual DbSet<Tbl_Institute_Bank_Details> Tbl_Institute_Bank_Details { get; set; }
        public virtual DbSet<Tbl_Institute_Logo_Details> Tbl_Institute_Logo_Details { get; set; }
        public virtual DbSet<Tbl_Institute_Master> Tbl_Institute_Master { get; set; }
        public virtual DbSet<View_InstituteList> View_InstituteList { get; set; }
        public virtual DbSet<Tbl_Menu> Tbl_Menu { get; set; }
        public virtual DbSet<Tbl_ModuleMaster> Tbl_ModuleMaster { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

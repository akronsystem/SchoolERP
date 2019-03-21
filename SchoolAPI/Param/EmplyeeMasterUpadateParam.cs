using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmplyeeMasterUpadateParam
    {
        public long EmployeeID { get; set; }


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


        public string AadharCardNo { get; set; }


        public string PANCardNo { get; set; }


        public string ImagePath { get; set; }


        public string Sign { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeAddressParam
    {
        public int EmployeeCode { get; set; }
        public long EmployeeID { get; set; }

        public string PermanentAddress { get; set; }

        public long PermanantStateID { get; set; }

        public long PermanantDistrictID { get; set; }

        public long PermanantTalukaID { get; set; }

        public string PermanantPincode { get; set; }

        public string PermanentCountry { get; set; }

        public string CorrespondanceAddress { get; set; }

        public long CorrespondanceStateID { get; set; }

        public long CorrespondanceDistrictID { get; set; }

        public long CorrespondanceTalukaID { get; set; }

        public string CorrespondancePincode { get; set; }

        public string CorrespondanceCountry { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
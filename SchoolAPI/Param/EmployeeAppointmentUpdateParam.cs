using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeAppointmentUpdateParam
    {
        public long AppointmentID { get; set; }

        public long EmployeeID { get; set; }

        public string AppointmentType { get; set; }

        public string JobType { get; set; }

        public DateTime JoiningDate { get; set; }

        public string SrGradeScaleApplicable { get; set; }

        public DateTime SrGradeScaleApplicableDate { get; set; }

        public string SelectionGradeScaleApplicable { get; set; }

        public DateTime SelectionGradeScaleApplicableDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
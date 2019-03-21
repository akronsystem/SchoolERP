namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_EmployeeAppointmentDetails
    {
        [Key]
        public long AppointmentID { get; set; }

        public long? EmployeeID { get; set; }

        [StringLength(50)]
        public string AppointmentType { get; set; }

        [StringLength(20)]
        public string JobType { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(5)]
        public string SrGradeScaleApplicable { get; set; }

        public DateTime? SrGradeScaleApplicableDate { get; set; }

        [StringLength(5)]
        public string SelectionGradeScaleApplicable { get; set; }

        public DateTime? SelectionGradeScaleApplicableDate { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Status { get; set; }

        public virtual Tbl_EmployeeMaster Tbl_EmployeeMaster { get; set; }
    }
}

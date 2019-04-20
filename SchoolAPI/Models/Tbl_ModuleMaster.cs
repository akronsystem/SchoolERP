namespace SchoolAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ModuleMaster
    {
        [Key]
        public long ModuleId { get; set; }

        [StringLength(100)]
        public string ModuleName { get; set; }

        public long ParentModuleId { get; set; }

        public long? ModuleOrder { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int Status { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }
    }
}

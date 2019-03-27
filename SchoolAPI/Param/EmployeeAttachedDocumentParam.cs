using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class EmployeeAttachedDocumentParam
    {
        //public long AttachmentID { get; set; }

        public long EmployeeID { get; set; }

  

        public string DocumentType { get; set; }

        public string Path { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
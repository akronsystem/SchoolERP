using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class AssignWidgetParam
    {
        public int AssignWidgetDID { get; set; }
        public string RoleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        public int Status { get; set; }

        public string WidgetIDs { get; set; }
        
        public string SequenceIDs{get;set;}

        public int AssignWidgetID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class WidgetUpdateParam
    {
        public long WidgetID { get; set; }
        public string WidgetName { get; set; }
        public string ActionName { get; set; }
        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }
    }
}
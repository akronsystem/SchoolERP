using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERP.Areas.SuperAdmin.Controllers
{
    public class WidgetMasterController : Controller
    {
        // GET: SuperAdmin/WidgetMaster
        public ActionResult Index()
        {
            return View("WidgetMaster");
        }
    }
}
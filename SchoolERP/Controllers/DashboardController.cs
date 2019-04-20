using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERP.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult DashboardWidget()
        {
            return View();
        }
        public ActionResult BirthdayWidget()
        {
            return View();
        }
        public ActionResult WelcomeWidget()
        {
            return View();
        }
        public ActionResult GalleryWidget()
        {
            return View();
        }
        public ActionResult AttendenceWidget()
        {
            return View();
        }
        public ActionResult ThoughtOfTheDayWidget()
        {
            return View();
        }
        public ActionResult TimeTableAdminWidget()
        {
            return View();
        }
        public ActionResult TeacherTimeTableWidget()
        {
            return View();

        }
        public ActionResult Calendar()
        {
            return View();
        }
     
        public ActionResult TodaysFeeCollectionWidget()
        {
            return View();

        }
       public ActionResult ExamMarkStatus()
        {
            return View();
        }
       
        public ActionResult FeeStatusGraphWidget()
        {
            return View();
        }
       
        public ActionResult ChartStandard()
        {
            return View();
        }
        public ActionResult MenuSubMenu()
        {
            return View();
        }
    }
}
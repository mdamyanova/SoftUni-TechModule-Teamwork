using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bYteMe.Controllers
{
    public class HomeController : Controller
    {
        //GET: Site Title and Subtitle
        public ActionResult Index()
        {
            ViewBag.SiteTitle = "bYte me";
            ViewBag.Subtitle = "stop the recursion of your love life";

            return View();
        }
    }
}
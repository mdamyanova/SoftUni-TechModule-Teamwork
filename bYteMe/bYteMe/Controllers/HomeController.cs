using System.Web.Mvc;

namespace bYteMe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Site Title and Subtitle
        public ActionResult Index()
        {
            this.ViewBag.SiteTitle = "bYte me";
            this.ViewBag.Subtitle = "сложете край на рекурсията в любовния ви живот";

            return this.View();
        }
    }
}
using System.Web.Mvc;

namespace bYteMe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Site Title and Subtitle
        public ActionResult Index()
        {
            this.ViewBag.SiteTitle = "bYte me";
            this.ViewBag.Subtitle = "stop the recursion of your love life";

            return this.View();
        }
    }
}
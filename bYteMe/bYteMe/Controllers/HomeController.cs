using System.Web.Mvc;

namespace bYteMe.Controllers
{
    using bYteMe.Constants;

    public class HomeController : Controller
    {
        // GET: Site Title and Subtitle
        public ActionResult Index()
        {
            this.ViewBag.SiteTitle = TextConstants.SiteTitle;
            this.ViewBag.Subtitle = TextConstants.SiteSubtitle;

            return this.View();
        }
    }
}
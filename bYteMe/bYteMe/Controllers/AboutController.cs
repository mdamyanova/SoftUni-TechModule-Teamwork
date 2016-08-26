namespace bYteMe.Controllers
{
    using System.Web.Mvc;

    using bYteMe.Constants;

    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.DescriptionText = TextConstants.AboutDescription;                
            return this.View();
        }
    }
}
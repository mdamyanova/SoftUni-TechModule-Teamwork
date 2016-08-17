namespace bYteMe.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
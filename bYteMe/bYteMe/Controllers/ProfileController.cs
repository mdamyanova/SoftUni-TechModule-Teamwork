namespace bYteMe.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            // TODO: Get current user and show info for him
            return this.View();
        }
    }
}
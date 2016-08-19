namespace bYteMe.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using bYteMe.Models;

    [Authorize]
    public class ProfilesController : Controller
    {
        public ActionResult Index()
        {
            var db = new bYteMeDbContext();

            var users = db.Users.Select(u => u).ToList();
            return this.View(users);
        }
    }
}
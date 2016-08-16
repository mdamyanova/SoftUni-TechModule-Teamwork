namespace bYteMe.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using bYteMe.Models;

    //[Authorize]
    public class ProfilesController : Controller
    {
        public ActionResult Index()
        {
           bYteMeDbContext bYteMeDbContext = new bYteMeDbContext();
            List<User> users = bYteMeDbContext.Users.Select(u => u).ToList();
            return this.View(users);
        }
    }
}
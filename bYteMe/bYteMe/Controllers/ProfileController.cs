namespace bYteMe.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using bYteMe.Constants;
    using bYteMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize]
    public class ProfileController : Controller
    {
        // get current user    
        private readonly User user =
            System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        readonly bYteMeDbContext db = new bYteMeDbContext();

        public ActionResult Index()
        {
            return this.View(this.user);
        }

        public ActionResult Gallery()
        {
            var photos = this.db.Photos.Where(p => p.AuthorId == this.user.Id).ToList();
            return this.View(photos);
        }

        public ActionResult AddPhoto()
        {
            return this.RedirectToAction("Gallery");
        }
    }
}
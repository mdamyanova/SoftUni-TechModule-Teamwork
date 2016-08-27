namespace bYteMe.Controllers
{
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
        private readonly User user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public ActionResult Index()
        {                                       
            return this.View(this.user);
        }

        public ActionResult Gallery()
        {
            var db = new bYteMeDbContext();
            var photos = db.Photos.Where(p => p.AuthorId == this.user.Id).ToList();
            return this.View(photos);
        }
    }
}
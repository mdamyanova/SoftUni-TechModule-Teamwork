namespace bYteMe.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using bYteMe.Constants;
    using bYteMe.Models;

    [Authorize]
    public class ProfileController : Controller
    {
        // get current user    
        private readonly User user = UserConstants.CurrentUser;

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
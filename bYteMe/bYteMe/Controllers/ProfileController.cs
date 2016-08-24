namespace bYteMe.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using bYteMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            // get current user          
            User user =
                System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
           
            // TODO: Get current user and show info for him
            return this.View(user);
        }

        //public ActionResult ViewProfile()
        //{
        //    return this.View();
        //}
    }
}
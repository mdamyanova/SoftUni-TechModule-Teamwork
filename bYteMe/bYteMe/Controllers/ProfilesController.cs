namespace bYteMe.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using bYteMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize]
    public class ProfilesController : Controller
    {
        readonly bYteMeDbContext db = new bYteMeDbContext();

        readonly User currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        public ActionResult Index()
        {
            var users = db.Users.Select(u => u).ToList();
            return this.View(users);
        }

        public ActionResult Likes(string id)
        {
            User user = this.db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null && user.Likes == null)
            {
                user.Likes = 0;
            }

            user.Likes = user.Likes + 1;
            if (user.Likes < 0)
            {
                user.Likes = 0;
            }

            this.db.Entry(user).State = EntityState.Modified;
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        public ActionResult Like(string name)
        {
            var user = this.db.Users.Select(u => u).First(u => u.UserName == name);
            if (user.Likes == null)
            {
                user.Likes = 0;
            }

            user.Likes = user.Likes + 1;
            if (user.Likes < 0)
            {
                user.Likes = 0;
            }

            if (user.Dislikes > 300)
            {
                user.Dislikes = 300;
            }

            this.db.Entry(this.currentUser).State = EntityState.Modified;
            this.db.Entry(user).State = EntityState.Modified;
            
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        public ActionResult Dislike(string name)
        {
            var user = this.db.Users.Select(u => u).First(u => u.UserName == name);
            if (user.Dislikes == null)
            {
                user.Dislikes = 0;
            }

            user.Dislikes = user.Dislikes + 1;
            if (user.Dislikes < 0)
            {
                user.Dislikes = 0;
            }

            if (user.Dislikes > 300)
            {
                user.Dislikes = 300;
            }

            this.db.Entry(user).State = EntityState.Modified;
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}
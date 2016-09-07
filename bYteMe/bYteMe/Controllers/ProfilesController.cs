namespace bYteMe.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using bYteMe.Models;

    //[Authorize]
    public class ProfilesController : Controller
    {
        private readonly bYteMeDbContext db = new bYteMeDbContext();

        public ActionResult Index()
        {
            var users = this.db.Users.Select(u => u).ToList();
            return this.View(users);
        }

        public ActionResult Likes(string id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == id);
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
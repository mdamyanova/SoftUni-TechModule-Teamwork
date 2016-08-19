using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace bYteMe.Controllers
{
    using bYteMe.Models;

    public class PostsController : Controller
    {
        private bYteMeDbContext db = new bYteMeDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return this.View(this.db.Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorId,PostId,Title,Body")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Posts.Add(post);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,PostId,Title,Body")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(post).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.db.Posts.Find(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var post = this.db.Posts.Find(id);
            this.db.Posts.Remove(post);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
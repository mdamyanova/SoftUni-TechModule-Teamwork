using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using bYteMe.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace bYteMe.Controllers
{
    using System.Data.Entity;

    [Authorize]
    public class ManageController : Controller
    {
        private readonly bYteMeDbContext db = new bYteMeDbContext();

        readonly User currentUser = System.Web.HttpContext.Current.GetOwinContext()
               .GetUserManager<ApplicationUserManager>()
               .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;
        

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this._signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

            private set 
            {
                this._signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this._userManager = value;
            }
        }

        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Паролата е променена."
                : message == ManageMessageId.SetPasswordSuccess ? "Паролата е зададена."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "Възникна грешка."
                : message == ManageMessageId.AddPhoneSuccess ? "Телефонният ви номер е добавен."
                : message == ManageMessageId.RemovePhoneSuccess ? "Телефонният ви номер е премахнат."
                : string.Empty;

            var userId = this.User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = this.HasPassword(),

                // PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                // TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await this.UserManager.GetLoginsAsync(userId),

                // BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return this.View(model);
        }

        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), true);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInManager.SignInAsync(user, false, false);
            }

            return this.RedirectToAction("Index", "Manage");
        }

        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), false);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInManager.SignInAsync(user, false, false);
            }

            return this.RedirectToAction("Index", "Manage");
        }

        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, false, false);
                }

                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            this.AddErrors(result);
            return this.View(model);
        }

#region AddedMethods
        public ActionResult EditProfile()
        {
            var user = this.db.Users.FirstOrDefault(u => u.UserName.Equals(this.currentUser.UserName));
            var model = new ExtendedIdentityModels { UserName = user?.UserName, FullName = user?.FullName, Email = user?.Email, ProfilePhoto = user?.ProfilePhoto, Biography = user?.Biography};

            return this.View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(User editedUser)
        {
            // TODO: Find out why ModelState.IsValid is False
            // if (ModelState.IsValid)
            // {

            User user = this.db.Users.FirstOrDefault(u => u.UserName.Equals(this.currentUser.UserName));
            if (this.db.Users.Any(u => u.UserName == editedUser.UserName))
            {
                this.ModelState.AddModelError("", "вече има пич с такова потребителско име");

            }
            if (this.db.Users.Any(u => u.Email == editedUser.Email))
            {
                this.ModelState.AddModelError("", "зает е имейла");

            }

            var userNameExists = this.db.Users.Any(x => x.UserName == editedUser.UserName);
            if (!userNameExists)
            {
                user.UserName = editedUser.UserName;
            }

            user.FullName = editedUser.FullName;
            var emailExists = this.db.Users.Any(x => x.Email == editedUser.Email);
            if (!emailExists)
            {
                user.Email = editedUser.Email;
            }                    
            user.ProfilePhoto = editedUser.ProfilePhoto;
            user.Biography = editedUser.Biography;
            this.db.Entry(user).State = EntityState.Modified;
            this.db.SaveChanges();
            return this.RedirectToAction("Index", "Home");

            // }                    
            // return this.View(editedUser);
        }

        //TODO: Make it work
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            while (this.db.Posts.Any(p => p.AuthorId == this.currentUser.Id))
            {
                var post = this.db.Posts.FirstOrDefault(p => p.AuthorId == this.currentUser.Id);
                this.db.Posts.Remove(post);
            }

            this.db.Users.Remove(this.currentUser);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && this._userManager != null)
            {
                this._userManager.Dispose();
                this._userManager = null;
            }

            base.Dispose(disposing);
        }      

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion    
    }
}
using System.Web;

using bYteMe.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace bYteMe.Constants
{
    public class UserConstants
    {
        public static readonly User CurrentUser =
            System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
    }
}
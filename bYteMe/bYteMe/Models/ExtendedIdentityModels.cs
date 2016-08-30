using System.Web;

namespace bYteMe.Models
{
    public class ExtendedIdentityModels : RegisterViewModel
    {
        public HttpPostedFileBase UserProfilePicture { get; set; }
    }
}
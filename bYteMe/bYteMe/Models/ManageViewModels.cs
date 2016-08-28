using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace bYteMe.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        // public string PhoneNumber { get; set; }
        // public bool TwoFactor { get; set; }
        // public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде най-малко {2} символа.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "потвърждаване на новата парола")]
        [Compare("NewPassword", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "текуща парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да е най-малко {2} символа.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "потвърдете новата парола")]
        [Compare("NewPassword", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "телефонен номер")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "телефонен номер")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}
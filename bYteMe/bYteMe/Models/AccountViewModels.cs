using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bYteMe.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "имейл")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "код")]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Запомняне на браузъра?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "потребителско име")]
        public string UserName { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "потребителско име")]
        public string Username { get; set; }

        // [Required]
        // [Display(Name = "Email")]
        // [EmailAddress]
        // public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "парола")]
        public string Password { get; set; }

        [Display(Name = "Запомняне?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [EmailAddress]
        [Display(Name = "имейл")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде най-малко {2} символа.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "потвърждаване на парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [Display(Name = "потребителско име")]
        [StringLength(50, ErrorMessage = "{0} трябва да бъде най-малко {2} символа.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "име и фамилия")]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде най-малко {2} символа.", MinimumLength = 5)]
        public string FullName { get; set; }

        [Display(Name = "биография")]
        public string Biography { get; set; }

        [Display(Name = "профилна снимка")]
        public byte[] ProfilePhoto { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "потребителско име")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} трябва да бъде най-малко {2} символа.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "потвърждаване на парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "имейл")]
        public string Email { get; set; }
    }
}
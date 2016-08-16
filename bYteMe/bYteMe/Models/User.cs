using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace bYteMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [Key]
        [Column(Order = 0)]
        public override string Id { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public override string UserName { get; set; }

        [Column(Order = 2)]
        [StringLength(100)]
        public string FullName { get; set; }

        //[Column(Order = 3)]
        //[MaxLength(64)]
        //public override string PasswordHash { get; set; }


        [Column(Order = 4)]
        public byte[] ProfilePhoto { get; set; }

        [Column(TypeName = "ntext")]
        public string Biography { get; set; }

        public int? Likes { get; set; }

        public int? Dislikes { get; set; }

        [Required]
        public string Password { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
           
            // Add custom user claims here
            return userIdentity;
        }
    }
}
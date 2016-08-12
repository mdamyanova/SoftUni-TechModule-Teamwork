using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace bYteMe.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // replace default connection with bYteMe database ? 
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<bYteMe.Models.Post> Posts { get; set; }
    }
}
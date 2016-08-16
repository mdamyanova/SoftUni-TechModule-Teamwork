using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace bYteMe.Models
{
    public class bYteMeDbContext : IdentityDbContext<User>
    {
        // replace default connection with bYteMe database ? 
        public bYteMeDbContext()
            : base("bYteMeDbContext", throwIfV1Schema: false)
        {
        }

        public static bYteMeDbContext Create()
        {
            return new bYteMeDbContext();
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public override IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
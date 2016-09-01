using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

namespace bYteMe.Models
{
    using System;

    public class bYteMeDbContext : IdentityDbContext<User>
    {
        // replace default connection with bYteMe database 
        public bYteMeDbContext()
            : base("bYteMeDbContext")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public override IDbSet<User> Users { get; set; }

        public static bYteMeDbContext Create()
        {
            return new bYteMeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
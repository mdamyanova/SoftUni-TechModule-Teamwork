namespace bYteMe
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bYteMeDbContext : DbContext
    {
        public bYteMeDbContext()
            : base("name=bYteMeDbContext")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}

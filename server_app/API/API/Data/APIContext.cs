using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DetailHistory> DetailHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey("id_user");

            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.User)
            //    .WithMany(u => u.Comments)
            //    .HasForeignKey("id_user");

            //modelBuilder.Entity<Comment>()
            //    .HasOne<User>(c => c.User)
            //    .WithMany(u => u.GetComments)
            //    .HasForeignKey(c => c.id_user);

            //modelBuilder.Entity<User>()
            //    .HasMany<Comment>(c => c.GetComments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey(c => c.id_user);

            //modelBuilder
            //    .Entity<User>(eb =>
            //    {
            //        eb.HasKey("id_user");
            //        eb.ToView("User");
            //        eb.Property(v => v.id_user).HasColumnName("id_user");
            //    });

            //modelBuilder
            //    .Entity<Comment>(eb =>
            //    {
            //        eb.HasKey("id_comment");
            //        eb.ToView("Comment");
            //        eb.Property(v => v.id_user).HasColumnName("id_user");
            //    });

            //modelBuilder
            //    .Entity<Category>(eb =>
            //    {
            //        eb.HasNoKey();
            //        eb.ToView("Category");
            //        eb.Property(v => v.id_category).HasColumnName("id_category");
            //    });

            //modelBuilder
            //    .Entity<Product>(eb =>
            //    {
            //        eb.HasNoKey();
            //        eb.ToView("Product");
            //        eb.Property(v => v.id_product).HasColumnName("id_product");
            //    });

            //modelBuilder
            //    .Entity<Cart>(eb =>
            //    {
            //        eb.HasNoKey();
            //        eb.ToView("Cart");
            //        eb.Property(v => v.id_cart).HasColumnName("id_cart");
            //    });
        }
    }
}

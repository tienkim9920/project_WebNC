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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<User>(eb =>
        //        {
        //            eb.HasNoKey();
        //            //eb.ToView("User");
        //            //eb.Property(v => v.id_user).HasColumnName("id_user");
        //        });

        //    modelBuilder
        //        .Entity<Category>(eb =>
        //        {
        //            eb.HasNoKey();
        //            eb.ToView("Category");
        //            eb.Property(v => v.id_category).HasColumnName("id_category");
        //        });

        //    modelBuilder
        //        .Entity<Product>(eb =>
        //        {
        //            eb.HasNoKey();
        //            eb.ToView("Product");
        //            eb.Property(v => v.id_product).HasColumnName("id_product");
        //        });

        //    modelBuilder
        //        .Entity<Cart>(eb =>
        //        {
        //            eb.HasNoKey();
        //            eb.ToView("Cart");
        //            eb.Property(v => v.id_cart).HasColumnName("id_cart");
        //        });
        //}
    }
}

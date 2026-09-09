using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using eCommerce.DataAccessLayer.Entities;

namespace eCommerce.DataAccessLayer
{
    public class ProductServiceDbContext : DbContext
    {

        public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}

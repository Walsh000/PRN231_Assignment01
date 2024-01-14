using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_KhuatThiMinhAnh_BusinessObjects.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
       : base(options)
        {
        }
        public AppDBContext() 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberID = 1,
                    CompanyName = "Company 1",
                    City = "City 1",
                    Country = "Country 1",
                    Email = "Admin",
                    Password = "Admin",
                },
                new Member
                {
                    MemberID = 2,
                    CompanyName = "Company 2",
                    City = "City 2",
                    Country = "Country 2",
                    Email = "Member2",
                    Password = "Member2",
                },
                new Member
                {
                    MemberID = 3,
                    CompanyName = "Company 3",
                    City = "City 3",
                    Country = "Country 3",
                    Email = "Member3",
                    Password = "Member3",
                }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Category 1",
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Category 2",
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}

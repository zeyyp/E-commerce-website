
using Microsoft.EntityFrameworkCore;
using shopping.web.Entity;

namespace shopping.web.Models;


public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer("Server=ZEYNEP\\SQLEXPRESS;Database=shoppingDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    public DbSet<Category> categories {get; set;} =null!;
    public DbSet<Product> products {get; set;}=null!;
    public DbSet<User> users {get; set;}=null!;
    public DbSet<Order> orders {get; set;}=null!;

}

using Microsoft.EntityFrameworkCore;

namespace shopping.web.Models;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer("Server=ZEYNEP\\SQLEXPRESS;Database=shoppingDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    public DbSet<Category> categories {get; set;} =null!;
    public DbSet<Product> products {get; set;}=null!;

}

using System.ComponentModel.DataAnnotations;
using shopping.web.Models;

namespace shopping.web.Entity;

public class Order
{
    [Key]
    public int Id {get; set;}

    public string? Name {get; set;}
    public DateTime OrderDate {get; set;}
    public string? Email { get; set; }
    public string? City { get; set; }
    public string? orderAdres { get; set; }


  public List<OrderItem> orderItems {get;set;} =new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order order { get; set; } = new();

    public int productId { get; set; }
    public Product product { get; set; } =new();
    public double price { get; set; }
    public int adet { get; set; }
}
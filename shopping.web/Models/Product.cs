
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.web.Models;

public class Product
{
  [Key]
    public int Id {get; set;}

    public string? Title {get; set;}
    public string? image {get; set;}
    public string? Description { get; set; }
    public decimal price { get; set; }

   // public int CategoryId { get; set; }
   // public virtual Category? Category {get; set;}
}
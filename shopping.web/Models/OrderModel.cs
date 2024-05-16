
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace shopping.web.Models;
public class OrderModel
{
   
    public int Id {get; set;}
      [Required(ErrorMessage ="Ad soyad girmeniz gerekiyor.")]
    public string? Name {get; set;}
    public DateTime OrderDate {get; set;}
    [EmailAddress]
    public string? Email { get; set; }
    public string? City { get; set; }
    [Required(ErrorMessage ="Adres girmeniz gerekiyor.")]
    public string? orderAdres { get; set; }
    [BindNever]
    public Basket? cart {get;set;} = null!;

}
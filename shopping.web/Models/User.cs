using System.ComponentModel.DataAnnotations;

namespace shopping.web.Models;

public class User
{
    [Key]
     
    public int UserId {get; set;}
    [Required(ErrorMessage ="Adınızı ve soyadınızı girmeniz gerekiyor.")]
    public string? AdSoyad {get; set;}

    [Required(ErrorMessage ="Sifre girmeniz gerekiyor.")]
    public string? Sifre {get; set;}

     [Required(ErrorMessage ="E-mail girmeniz gerekiyor.")]
     [EmailAddress]
    public string? Email {get; set;}


    public string? UserAdres {get; set;}
}
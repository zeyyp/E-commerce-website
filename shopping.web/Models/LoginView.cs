namespace shopping.web.Models;
using System.ComponentModel.DataAnnotations;

public class LoginView
{
    [Required(ErrorMessage ="E-mail girmeniz gerekiyor.")]
     [EmailAddress]
    public string? Email {get; set;}

    [Required(ErrorMessage ="Sifre girmeniz gerekiyor.")]
    public string? Sifre {get; set;}

}
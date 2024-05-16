using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace shopping.web.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public string? Url {get; set;}

  
}
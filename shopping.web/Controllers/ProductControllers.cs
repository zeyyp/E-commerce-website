
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopping.web.Models;

namespace shopping.web.Controllers;

public class ProductController : Controller
{
     Context c = new Context();
    public async Task<IActionResult> Index()
    {
       var urunler = await c.products.ToListAsync(); //asekron sorgu
        
        return View(urunler);
    }
}
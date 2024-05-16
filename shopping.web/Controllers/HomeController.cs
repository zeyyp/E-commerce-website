using Microsoft.AspNetCore.Mvc;


namespace shopping.web.Controllers;


public class HomeController : Controller
{
   
     
   public IActionResult Index()
    {
        return RedirectToAction("Index", "Product");
    }


}
using Microsoft.AspNetCore.Mvc;
using shopping.web.Models;

namespace shopping.web.Controllers;



public class BasketController : Controller
{
   
     private Context db = new Context();

     public Basket? cart {get;set;}

   public ActionResult Index()
   {
        return View(GetCart());
   }
    
    
    public Basket GetCart()
    {                  //serverda bilgi bırakmak ıcın
        cart = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
        
        return cart;
    }
     public IActionResult SepeteEkle(int Id)
    {
        var product = db.products.FirstOrDefault(i=>i.Id == Id);

        if(product !=null)
        {  
            cart = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();    
            cart.AddProduct(product,1);
            HttpContext.Session.SetJson("Basket",cart);
        }

        return RedirectToAction("Index");
    }

    
}
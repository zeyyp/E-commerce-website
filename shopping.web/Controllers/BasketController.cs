using Microsoft.AspNetCore.Mvc;
using shopping.web.Models;


namespace shopping.web.Controllers;



public class BasketController : Controller
{
   
     private Context db = new Context();

   public ActionResult Index()
   {
        return View(GetCart());
   }

    public Basket? cart {get;set;}
    public Basket GetCart()
    {
         cart = HttpContent.Session.GetJson<Basket>("urun") ?? new Basket();
         if(cart ==null)
         {
            cart =new Basket();
            HttpContent.Session.GetJson("urun",cart);
         }
        return cart;
    }
     public IActionResult SepeteEkle(int Id)
    {
        var product = db.products.FirstOrDefault(i=>i.Id == Id);

        if(product !=null)
        {      
            GetCart().AddProduct(product,1);
            HttpContent.Session.SetJson("urun",cart);
        }

        return RedirectToAction("index");
    }

    public IActionResult RemoveCart(int Id)
    {
        var product = db.products.FirstOrDefault(i=>i.Id == Id);

        if(product !=null)
        {      
            GetCart().RemoveProduct(product);
           // HttpContent.Session.SetJson("urun",cart);
        }

        return RedirectToAction("index");
    }
}
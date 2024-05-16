
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping.web.Entity;
using shopping.web.Models;

namespace shopping.web.Controllers;

public class OrderController : Controller
{
   
    Basket basket = new Basket();
    
    Context db=new Context();

    // [Authorize]
    public IActionResult Siparis()
    {
        return View(new OrderModel() {cart = basket});
    }


    [HttpPost]
    public ActionResult Siparis(OrderModel entity)
    {
       var cart = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();

       if(ModelState.IsValid)
       {
            SaveOrder(cart,entity);
            //veritaban kaydet
            
             return RedirectToAction("Completed", "Order");
       }
        return View(entity);
    }

    private void SaveOrder(Basket cart, OrderModel entity)
    {
        var order = new Order();
        order.Name=entity.Name;
        order.Email=entity.Email;
        order.orderAdres=entity.orderAdres;
        order.OrderDate=DateTime.Now;

        order.orderItems = new List<OrderItem>();
        foreach(var pr in order.orderItems)
        {
            OrderItem orderline =new OrderItem();
            orderline.adet =pr.adet;
            orderline.price=pr.price;

            order.orderItems.Add(orderline);
        }
        db.orders.Add(order);
        db.SaveChanges();
    }

     public IActionResult Completed()
    {
        return View();
    }
}
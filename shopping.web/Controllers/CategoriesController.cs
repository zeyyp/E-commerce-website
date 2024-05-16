using Microsoft.AspNetCore.Mvc;
using shopping.web.Models;

namespace shopping.web.Controllers;

public class CategoriesController : Controller
{
    Context c= new Context();

    public ActionResult Index()
    {
        var kategoriler = c.categories.ToList();
        return View(kategoriler);
    }

    public ActionResult CategoryDetail(int id)
    {
        var urunler = c.products.Where(x=>x.CategoryId==id).ToList();
        return View(urunler);
    }
}
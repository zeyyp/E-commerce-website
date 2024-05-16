using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using shopping.web.Models;

namespace shopping.web.Controllers;

public class UserController : Controller
{
    

    Context _context = new Context();

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User model)
    {
        if(ModelState.IsValid) // butun kontroller dogru
        {
                 _context.users.Add(model);
                   await _context.SaveChangesAsync();
                   return RedirectToAction("Index", "Product");
        }
         return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginView model)
    {
        if(ModelState.IsValid) // butun kontroller dogru
        {
                var userControl = _context.users.FirstOrDefault(x=>x.Email== model.Email 
                                                       && x.Sifre==model.Sifre);

                if(userControl !=null) // kullanıcı dogrulandı
                {
                        var userClaims =new List<Claim>();
                                    //kullanıcı hakkında tutulacak olan talepler (claims) listesi 

                        userClaims.Add(new Claim(ClaimTypes.NameIdentifier,userControl.UserId.ToString()));
                        userClaims.Add(new Claim(ClaimTypes.Name,userControl.AdSoyad ?? ""));

                        var claimsIdentity = new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                        new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("Index", "Product");

                }

                else
             {
                    ModelState.AddModelError("","E-mail veya sifre yanlış");
             }
        }

        
         return View(model);
    }

}
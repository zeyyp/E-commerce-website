using System.Data.SqlTypes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Options;
using shopping.web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

  
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
  {
         options.IdleTimeout = TimeSpan.FromMinutes(30);
         options.Cookie.IsEssential = true;
  }     

);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();




app.UseStaticFiles();  // statik dosyalarımızı tanıttık

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
        name:  "default",
        pattern: "{contoller=Product}/{action=Index}/{id?}");
app.Run();

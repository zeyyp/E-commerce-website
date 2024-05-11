using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using shopping.web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
        // controllers ile views ilişkilendirdik

// builder.Services.AddDbContext<Context>(
        
//     options => options.UseSqlServer(builder.Configuration["ConnectionStrings:sql_Connection"],
//     b=>b.MigrationsAssembly("shopping.web"))
// );

//builder.Services.AddScoped<IStoreRepository, efStoreRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();



//seedData.verileriEkle(app);

app.UseStaticFiles();  // statik dosyalarımızı tanıttık
app.UseSession();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
        name:  "default",
        pattern: "{contoller=product}/{action=Index}/{id?}");
app.Run();

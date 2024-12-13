using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services;
using WebProje.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);
var conStr = builder.Configuration.GetConnectionString("Default");

//tanımladık bunun sayesinde illa bizdn auth isticek
//var requireAuthorizePolicy =new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddDbContext<WebDbContext>(x =>
    x.UseSqlServer(conStr));
// MVC ve Razor sayfalar için gerekli servisler
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<WebDbContext>();

/*builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});*/

builder.Services.AddControllersWithViews();

//farklı sayfayı açmaya çalışsak bile auth isticek yönlendircek
/*builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index/";
});*/

builder.Services.AddScoped<IUrunService, UrunService>();
builder.Services.AddScoped<IKategoriService, KategoriService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Statik dosyaları hem 'wwwroot' hem de 'Web/dist' klasöründen sunacak şekilde yapılandırıyoruz
app.UseStaticFiles();  // wwwroot klasöründeki dosyaları sunmak için

// Hata yönetimi ve yönlendirme
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Ana route yapılandırması
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
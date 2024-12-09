using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.EfCore;
using WebProje.Models;

namespace WebProje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WebDbContext _context;
    
    

    public HomeController(ILogger<HomeController> logger, WebDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Kayit()
    {
        var ornekKayit = _context.Kullanicilar
            .OrderByDescending(k => k.KullaniciId)  // ID'ye göre azalan sırada sıralama
            .FirstOrDefault();  // İlk elemanı al
        
        var isimler = new List<string>() { "Eren", "Ali" };
        ViewData["sec"] = isimler.Select(x => new SelectListItem
        {
            Text = x,
            Value = x
        }).ToList();
        ViewBag.ornekKayit = ornekKayit;
        return View();
    }
    
    [HttpPost]
    public IActionResult Kayit(Kullanici input)
    {
        
        _context.Kullanicilar.Add(input);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult Menu()
    {
        var menuItems = _context.Uruns.ToList();

        return View(menuItems);
    }

    public IActionResult Privacy()
    {
        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
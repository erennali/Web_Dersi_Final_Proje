using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUrunService _urunService;
    private readonly IKategoriService _kategoriService;
    
    

    public HomeController(ILogger<HomeController> logger, IUrunService urunService, IKategoriService kategoriService)
    {
        _logger = logger;
        _urunService = urunService;
        _kategoriService = kategoriService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Menu(string selectedCategory)
    {
        // Kategorileri al
        ViewData["Categories"] = new SelectList(_kategoriService.GetTumKategoriler(), "Id", "Ad");

        // Ürünleri filtrele
        var urunler = _urunService.GetUrunlerByCategory(selectedCategory);
        return View(urunler);
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
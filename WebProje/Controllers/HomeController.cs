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
    
    
    public IActionResult Menu(string selectedCategory,Guid MasaId)
    {
        //kategorileri cekme
        ViewData["Categories"] = new SelectList(_kategoriService.GetTumKategoriler(), "Id", "Ad");

        // ürünleri kategorilere göre filtreleme
        var urunler = _urunService.GetUrunlerByCategory(selectedCategory);
        return View(urunler);
    }
    public IActionResult QRIndex(Guid id)
    {
        ViewBag.MasaId = id;
        return View(id);
        //http://localhost:5159/Home/QRIndex/c9448087-2878-45eb-bbde-07ceac9fcc22 örnek kullanım Masa01
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
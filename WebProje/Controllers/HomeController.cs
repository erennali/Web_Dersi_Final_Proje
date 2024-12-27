using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using WebProje.EfCore;
using WebProje.Hubs;
using WebProje.Models;
using WebProje.Services;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUrunService _urunService;
    private readonly IKategoriService _kategoriService;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly WebDbContext _context;

    public HomeController(ILogger<HomeController> logger, IUrunService urunService, IKategoriService kategoriService, IHubContext<NotificationHub> hubContext, WebDbContext context)
    {
        _logger = logger;
        _urunService = urunService;
        _kategoriService = kategoriService;
        _hubContext = hubContext;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    
    public IActionResult Menu(string selectedCategory)
    {
        //kategorileri cekme
        ViewData["Categories"] = new SelectList(_kategoriService.GetTumKategoriler(), "Id", "Ad");

        // ürünleri kategorilere göre filtreleme
        var urunler = _urunService.GetUrunlerByCategory(selectedCategory);
      
        return View(urunler);
    }
    public IActionResult QRMenu(string selectedCategory, Guid masaId)
    {
        ViewData["masaId"] = masaId; // masaId'yi ViewData'ya gönderiyoruz
        ViewData["Categories"] = new SelectList(_kategoriService.GetTumKategoriler(), "Id", "Ad");
        var urunler = _urunService.GetUrunlerByCategory(selectedCategory);
        return View(urunler);
    }
    
    public IActionResult QRIndex(Guid id)
    {
        ViewBag.MasaId = id;
        return View(id);
        //http://localhost:5159/Home/QRIndex/c9448087-2878-45eb-bbde-07ceac9fcc22
        //örnek kullanım Masa01
    }
    
    [HttpGet]
    public IActionResult CallWaiter(Guid masaId)
    {
        // Masa bilgilerini veritabanından çek
        var masa = _context.Masalar.FirstOrDefault(m => m.Id == masaId);
        if (masa == null)
        {
            TempData["ErrorMessage"] = "Masa bulunamadı.";
            return RedirectToAction("Index", "Home");
        }

        // Bildirimi SignalR ile admin paneline gönder
        _hubContext.Clients.All.SendAsync(
            "ReceiveNotification",
            masa.Id,
            $"Masa :  {masa.Ad} garson çağırdı."
        );
        return RedirectToAction("QRIndex", new { id = masaId });
    }
    [HttpGet]
    public IActionResult RequestBill(Guid masaId)
    {
        // Masa bilgilerini veritabanından çek
        var masa = _context.Masalar.FirstOrDefault(m => m.Id == masaId);
        if (masa == null)
        {
            TempData["ErrorMessage"] = "Masa bulunamadı.";
            return RedirectToAction("Index", "Home");
        }

        // Bildirimi SignalR ile admin paneline gönder
        _hubContext.Clients.All.SendAsync(
            "ReceiveNotification",
            masa.Id,
            $"Masa :  {masa.Ad} hesap istedi."
        );
        return RedirectToAction("QRIndex", new { id = masaId });
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
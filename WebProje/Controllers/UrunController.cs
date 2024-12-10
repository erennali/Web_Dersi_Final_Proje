using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;


[Authorize(Roles = "Admin")]
public class UrunController : Controller
{
    private readonly IUrunService _urunService;
    private readonly IKategoriService _kategoriService;

    public UrunController(IUrunService urunService, IKategoriService kategoriService)
    {
        _urunService = urunService;
        _kategoriService = kategoriService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> AdminMenu()
    {
        var kategoriAdlari = await _urunService.KategoriDegerleri2();
        ViewBag.KategoriAdlari = kategoriAdlari;
        var menuItems = await _urunService.GetTumUrunler();

        return View(menuItems);
    }
    
    public IActionResult Ekle()
    {
        var kategoriler = _kategoriService.GetTumKategoriler();
        ViewData["Markalar"] = new SelectList(kategoriler, "Id", "Ad");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Ekle(Urun urun)
    {
        await _urunService.Ekle(urun);
        return RedirectToAction(nameof(AdminMenu));
    }
    
    public async Task<IActionResult> UrunSil(Guid id)
    {
        await _urunService.Sil(id);
        return RedirectToAction(nameof(AdminMenu));
    }
    
    public async Task<IActionResult> UrunGetir(Guid id)
    {
        var deger1 = await _urunService.KategoriDegerleri();
        ViewBag.dgr1 = deger1;
        var getirilenurun = await _urunService.Getir(id);
        return View("UrunGetir",getirilenurun);
    }
    
    public async Task<IActionResult> UrunGuncelle(Urun urun)
    {
        await _urunService.Guncelle(urun);
        return RedirectToAction(nameof(AdminMenu));
    }
    
    
}
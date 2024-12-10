using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

[Authorize(Roles = "Admin")]
public class KategoriController : Controller
{
    private IKategoriService _kategoriService;

    public KategoriController(IKategoriService kategoriService)
    {
        _kategoriService = kategoriService;
    }

    public IActionResult Index()
    {
        var kategoriler =  _kategoriService.GetTumKategoriler();
        return View(kategoriler);
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Kategori input)
    {
        _kategoriService.Ekle(input);

        return RedirectToAction("Index");
    }


    public IActionResult Guncelle(int id)
    {
        var kategori = _kategoriService.GetKategoribyId(id);

        return View(kategori);
    }

    [HttpPost]
    public IActionResult Guncelle(Kategori input)
    {
        _kategoriService.Guncelle(input);

        return RedirectToAction("Index");
    }

    public  IActionResult Sil(int id)
    {
        _kategoriService.Sil(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("Sil")]
    public IActionResult SilOnaylanmis(int id)
    {
        _kategoriService.Sil(id);

        return RedirectToAction(nameof(Index));
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

[Authorize(Roles = "Admin")]

public class MasaController : Controller
{
    private readonly IMasaService _masaService;

    public MasaController(IMasaService masaService)
    {
        _masaService = masaService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var masalar =await _masaService.GetAll();
        return View(masalar);
    }
    [HttpGet]
    public async Task<IActionResult> Ekle()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Ekle(Masa masa)
    {
        await _masaService.Ekle(masa);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Sil(Guid id)
    {
        await _masaService.Sil(id);
        return RedirectToAction(nameof(Index));
    }
    
}
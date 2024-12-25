using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

public class RezervasyonController : Controller
{
    private readonly IRezervasyonService _rezervasyonService;

    public RezervasyonController(IRezervasyonService rezervasyonService)
    {
        _rezervasyonService = rezervasyonService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(Rezervasyon rezervasyon)
    {
        if (ModelState.IsValid) 
        {
            try
            {
                await _rezervasyonService.Ekle(rezervasyon);
                TempData["SweetAlertMesaj"] = "Rezervasyon Talebiniz Gonderildi!";
            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = "Bir hata olustu: " + ex.Message;
            }

            return RedirectToAction("Index");  
        }
        return View(rezervasyon);
        
                
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Rezervasyonlar()
    {
        var contacts = await _rezervasyonService.GetTumRezervasyon();
        var successRezervasyon = await _rezervasyonService.GetSuccessRezervasyon();
        ViewData["SuccessRezervasyon"] = successRezervasyon;

        return View(contacts);
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Success(Rezervasyon rezervasyon)
    {
        await _rezervasyonService.Success(rezervasyon);

        return RedirectToAction("Rezervasyonlar", "Rezervasyon");
    }
}
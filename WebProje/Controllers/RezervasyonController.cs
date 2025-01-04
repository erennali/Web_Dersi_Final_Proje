using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //server side validation
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
    public async Task<IActionResult> Rezervasyonlar( int pageNumber = 1)
    {
        var contacts = await _rezervasyonService.GetTumRezervasyon();
        //var successRezervasyon = await _rezervasyonService.GetSuccessRezervasyon();
        //bu server side pagination kullanmadan önceydi
        const int pageSize = 3;
        var successQuery = _rezervasyonService.GetSuccessRezervasyonQuery(); // IQueryable dönen yeni method

        //tek sayfada 3 adet olacak şekilde sayfalama yaptık ,onaylanan rezervasyonlarda 3 yeterli geldi
        var totalItems = await successQuery.CountAsync();
        var successItems = await successQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var paginatedSuccess = new PaginatedList<Rezervasyon>(successItems, totalItems, pageNumber, pageSize);
        ViewData["SuccessRezervasyon"] = paginatedSuccess;
        //ViewData["SuccessRezervasyon"] = successRezervasyon;

        return View(contacts);
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Success(Rezervasyon rezervasyon)
    {
        await _rezervasyonService.Success(rezervasyon);

        return RedirectToAction("Rezervasyonlar", "Rezervasyon");
    }
}
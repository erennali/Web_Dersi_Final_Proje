using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

[Authorize(Roles = "Admin")]
public class CouponController : Controller
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var kuponlar =await _couponService.GetAll();
        return View(kuponlar);
    }
    [HttpGet]
    public async Task<IActionResult> Ekle()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Ekle(Coupon coupon)
    {
        await _couponService.Ekle(coupon);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Sil(int id)
    {
        await _couponService.Sil(id);
        return RedirectToAction(nameof(Index));
    }
}
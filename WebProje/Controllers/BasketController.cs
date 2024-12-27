using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly WebDbContext _context;

    public BasketController(IBasketService basketService, WebDbContext context)
    {
        _basketService = basketService;
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SepeteEkle([FromBody] Basket sepetUrun)
    {
        var masaId = sepetUrun.MasaId;
        var basket = new Basket
        {
            ProductName = sepetUrun.ProductName,
            ProductDescription = sepetUrun.ProductDescription,
            ProductPrice = sepetUrun.ProductPrice,
            Status = false
        };

        // Sepete eklenen ürünün MasaId'sini burada ekliyoruz.
        await _basketService.Ekle(basket, sepetUrun.MasaId);
    
        return Json(new { success = true, message = "Ürün sepete eklendi!" });
    }
    [HttpGet]
    public IActionResult GetSepet(Guid masaId, string couponCode)
    {
        var basketItems = _context.Baskets
            .Where(b => b.MasaId == masaId && b.Status == false)
            .ToList();

        // Sepet boşsa
        if (basketItems == null || basketItems.Count == 0)
        {
            return View(new List<Basket>());
        }

        // Kupon kodu varsa ve daha önce uygulanmamışsa
        if (!string.IsNullOrEmpty(couponCode) && basketItems.Any(b => !b.IsCouponApplied))
        {
            couponCode.ToUpper();
            var coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode == couponCode);
            if (coupon != null)
            {
                // Kupon geçerli, indirimi uygula
                foreach (var b in basketItems)
                {
                    if (!b.IsCouponApplied) // Eğer kupon uygulanmamışsa
                    {
                        b.ProductPrice -= b.ProductPrice * (coupon.Discount / 100);
                        b.IsCouponApplied = true; // Kuponu uyguladığını işaretle
                    }
                }

                // Değişiklikleri kaydedelim
                _context.SaveChanges();
                TempData["SweetAlertMesaj"] = $"Kupon basariyla uygulandi! %{coupon.Discount} indirim yapildi.";
            }
            else
            {
                TempData["SweetAlertMesaj"] = "Gecersiz kupon kodu!";
            }
        }

        return View(basketItems);
    }
    [HttpPost]
    public IActionResult SiparisVer(Guid masaId)
    {
        var basketItems = _context.Baskets
            .Where(b => b.MasaId == masaId && b.Status == false)
            .ToList();

        if (basketItems != null && basketItems.Any())
        {
            foreach (var item in basketItems)
            {
                item.Status = true; 
            }

            _context.SaveChanges(); 
        }
        return RedirectToAction("GetSepet", new { masaId });
    }

    [HttpPost]
    public IActionResult Sil(Guid masaId, string productName)
    {
        var basketItem = _context.Baskets
            .FirstOrDefault(b => b.MasaId == masaId && b.ProductName == productName);

        if (basketItem != null)
        {
            _context.Baskets.Remove(basketItem);  
            _context.SaveChanges();  
        }

        
        return RedirectToAction("GetSepet", new { masaId });
    }
    
}
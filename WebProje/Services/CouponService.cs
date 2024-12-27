using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class CouponService : ICouponService
{
    private readonly WebDbContext _context;

    public CouponService(WebDbContext context)
    {
        _context = context;
    }


    public async Task Ekle(Coupon coupon)
    {
        _context.Coupons.Add(coupon);
        await _context.SaveChangesAsync();
    }

    public async Task Sil(int id)
    {
        var seciliKupon = await _context.Coupons.FindAsync(id);

        if (seciliKupon is null)
            return;

        _context.Coupons.Remove(seciliKupon);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Coupon>> GetAll()
    {
        return await _context.Coupons
            .ToListAsync();
    }
}
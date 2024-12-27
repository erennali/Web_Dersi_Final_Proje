using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface ICouponService
{
    Task Ekle(Coupon coupon);
    Task Sil(int id);
    Task<List<Coupon>> GetAll();
}
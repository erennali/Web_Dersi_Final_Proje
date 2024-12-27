using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IBasketService
{
    Task<List<Basket>> GetTumOrder();
    Task Ekle(Basket basket , Guid masaId);
    
    Task BuyOrder(Basket basket);
}
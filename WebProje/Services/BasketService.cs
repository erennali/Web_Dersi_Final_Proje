using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class BasketService : IBasketService
{
    private readonly WebDbContext _context;

    public BasketService(WebDbContext context)
    {
        _context = context;
    }

    public async Task<List<Basket>> GetTumOrder()
    {
        var baskets = await _context.Baskets
            .Where(x => x.Status == true)
            .Include(x => x.Masa) 
            .ToListAsync();

        foreach (var basket in baskets)
        {
            var masa = await _context.Masalar
                .FirstOrDefaultAsync(m => m.Id == basket.MasaId);

            if (masa != null)
            {
                basket.Masa = masa; // Mevcut Basket nesnesine Masa nesnesini ekle
            }
        }

        return baskets;
    }

    public async Task Ekle(Basket basket , Guid masaId)
    {
        basket.MasaId = masaId;
        _context.Baskets.Add(basket);
        await _context.SaveChangesAsync();
    }

    public async Task BuyOrder(Basket basket)
    {
        throw new NotImplementedException();
    }
}
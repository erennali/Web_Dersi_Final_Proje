using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class MasaService : IMasaService
{
    private readonly WebDbContext _context;

    public MasaService(WebDbContext context)
    {
        _context = context;
    }


    public async Task Ekle(Masa masa)
    {
        masa.Id = Guid.NewGuid();
        _context.Masalar.Add(masa);
        await _context.SaveChangesAsync();
    }

    public async Task Sil(Guid id)
    {
        var seciliMasa = await _context.Masalar.FindAsync(id);

        if (seciliMasa is null)
            return;

        _context.Masalar.Remove(seciliMasa);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Masa>> GetAll()
    {
        return await _context.Masalar
            .ToListAsync();
    }
}
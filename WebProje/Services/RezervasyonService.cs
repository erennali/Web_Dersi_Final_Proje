using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class RezervasyonService : IRezervasyonService
{
    private readonly WebDbContext _context;
    private readonly IMailService _mailService;

    public RezervasyonService(WebDbContext context, IMailService mailService)
    {
        _context = context;
        _mailService = mailService;
    }

    public async Task<List<Rezervasyon>> GetTumRezervasyon()
    {
        return await _context.Rezervasyonlar
            .Where(x=> x.Durum == true)
            .ToListAsync();
    }

    public async Task<List<Rezervasyon>> GetSuccessRezervasyon()
    {
        return await _context.Rezervasyonlar
            .Where(x=> x.Durum == false)
            .ToListAsync();
    }

    public async Task Ekle(Rezervasyon rezervasyon)
    {
        rezervasyon.Durum = true;
        _context.Rezervasyonlar.Add(rezervasyon);
        await _context.SaveChangesAsync();
    }

    public async Task Success(Rezervasyon rezervasyon)
    {
        var seciliRezerv = await _context.Rezervasyonlar.FindAsync(rezervasyon.Id);
        seciliRezerv.Durum = false;
        await _context.SaveChangesAsync();
        _mailService.RezervasyonMailGonder(seciliRezerv);
    }
}
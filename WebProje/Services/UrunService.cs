using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class UrunService : IUrunService
{
    private readonly WebDbContext _webDbContext;

    public UrunService(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }

    public async Task<List<Urun>> GetTumUrunler()
    {
        return await _webDbContext.Uruns
            //.Where(x=> x.Aktiflik)
            .ToListAsync();
    }

    public Task<Urun> GetUrunbyId(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Ekle(Urun urun)
    {
        urun.Id = Guid.NewGuid();
        _webDbContext.Uruns.Add(urun);
        await _webDbContext.SaveChangesAsync();
    }

    public async Task Guncelle(Urun urun)
    {
        if (urun is null)
            return;

        var seciliUrun = await _webDbContext.Uruns.FindAsync(urun.Id);
        if (seciliUrun is null)
            return;

        seciliUrun.Name = urun.Name;
        seciliUrun.Description = urun.Description;
        seciliUrun.Price = urun.Price;
        seciliUrun.ImageUrl = urun.ImageUrl;
         seciliUrun.KategoriId = urun.KategoriId;

        await _webDbContext.SaveChangesAsync();
    }

    public async Task Sil(Guid id)
    {
        var seciliUrun = await _webDbContext.Uruns.FindAsync(id);

        if (seciliUrun is null)
            return;

        _webDbContext.Uruns.Remove(seciliUrun);
        await _webDbContext.SaveChangesAsync();
    }
    public async Task<Urun> Getir(Guid id)
    {
        return await _webDbContext.Uruns.FindAsync(id);
    }
    public async Task<List<SelectListItem>> KategoriDegerleri()
    {
        var degerler = await (from x in _webDbContext.Kategoriler
            select new SelectListItem
            {
                Text = x.Ad,
                Value = x.Id.ToString()
            }).ToListAsync();
        return degerler;
    }
    public async Task<Dictionary<int, string>> KategoriDegerleri2()
    {
        Dictionary<int, string> kategoriAdlari = await _webDbContext.Kategoriler
            .ToDictionaryAsync(k => k.Id, k => k.Ad);
        return kategoriAdlari;
    }

    public List<Urun> GetUrunlerByKategori(int? kategoriId)
    {
        throw new NotImplementedException();
    }

    // Kategorilere göre filtrelenmiş ürünleri al
    // public List<Urun> GetUrunlerByKategori(int? kategoriId)
    // {
    //     var urunler = _webDbContext.Uruns.Include(u => u.KategoriFk).AsQueryable();
    //
    //     if (kategoriId.HasValue)
    //     {
    //         urunler = urunler.Where(u => u.KategoriId == kategoriId.Value);
    //     }
    //
    //     return urunler.ToList();
    // }
    // Kategorilere göre ürünleri filtreleme
    public List<Urun> GetUrunlerByCategory(string categoryId = null)
    {
        var urunler = _webDbContext.Uruns.Include(u => u.KategoriFk).AsQueryable();

        if (!string.IsNullOrEmpty(categoryId))
        {
            urunler = urunler.Where(u => u.KategoriId.ToString() == categoryId);
        }

        return urunler.ToList();
    }
    
}
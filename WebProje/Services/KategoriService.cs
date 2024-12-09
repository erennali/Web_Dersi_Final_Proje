using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class KategoriService : IKategoriService
{
    private readonly WebDbContext _webDbContext;

    public KategoriService(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }

    public List<Kategori> GetTumKategoriler()
    {
        return _webDbContext.Kategoriler
            .OrderBy(x=> x.Ad)
            .ToList();
    }

    public Kategori GetKategoribyId(int id)
    {
        var marka = _webDbContext.Kategoriler
            .FirstOrDefault(x => x.Id == id);

        return marka;
    }

    public void Ekle(Kategori eklenecek)
    {
        _webDbContext.Kategoriler.Add(eklenecek);
        _webDbContext.SaveChanges();
    }

    public void Guncelle(Kategori kategori)
    {
        var guncellenecekKategori = _webDbContext.Kategoriler
            .Find(kategori.Id);

        if (guncellenecekKategori != null)
        {
            guncellenecekKategori.Ad = kategori.Ad;
        }

        _webDbContext.SaveChanges();
    }

    public void Sil(int id)
    {
        var silinecekKategori = _webDbContext.Kategoriler
            .Find(id);

        if (silinecekKategori is null)
            return;

        _webDbContext.Kategoriler.Remove(silinecekKategori);
        _webDbContext.SaveChanges();
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IUrunService
{
    Task<List<Urun>> GetTumUrunler();
    Task<Urun> GetUrunbyId(Guid id);

    Task Ekle(Urun urun);
        
    Task Guncelle(Urun urun);

    Task Sil(Guid id);
    
    Task<Urun> Getir(Guid id);
    Task<List<SelectListItem>> KategoriDegerleri();
    Task<Dictionary<int, string>> KategoriDegerleri2();
}
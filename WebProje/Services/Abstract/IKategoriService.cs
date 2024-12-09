using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IKategoriService
{
    List<Kategori> GetTumKategoriler();

    Kategori GetKategoribyId(int id);

    void Ekle(Kategori eklenecek);
    void Guncelle(Kategori kategori);
    void Sil(int id);
}
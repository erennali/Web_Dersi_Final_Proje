using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IMasaService
{
    Task Ekle(Masa masa);
    Task Sil(Guid id);
    Task<List<Masa>> GetAll();
}
using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IRezervasyonService
{
    Task<List<Rezervasyon>> GetTumRezervasyon();
    
    Task<List<Rezervasyon>> GetSuccessRezervasyon();
    
    Task Ekle(Rezervasyon rezervasyon);
    
    Task Success(Rezervasyon rezervasyon);
}
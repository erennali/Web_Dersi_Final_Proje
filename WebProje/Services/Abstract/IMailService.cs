using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IMailService
{
    void Gonder(Mail mail);
    void RezervasyonMailGonder(Rezervasyon rezervasyon);
}
using WebProje.Models;

namespace WebProje.Services.Abstract;

public interface IContactService
{
    Task<List<Contact>> GetTumContacts();
    
    Task<List<Contact>> GetSolvedContacts();
    
    Task Ekle(Contact contact);
    Task Solved(Contact contact);
}
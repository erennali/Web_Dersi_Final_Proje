using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Services;

public class ContactService : IContactService
{
    private readonly WebDbContext _context;

    public ContactService(WebDbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetTumContacts()
    {
        return await _context.Contacts
            .Where(x=> x.Durum == true)
            .ToListAsync();
    }
    public async Task<List<Contact>> GetSolvedContacts()
    {
        return await _context.Contacts
            .Where(x=> x.Durum == false)
            .ToListAsync();
    }

    public async Task Ekle(Contact contact)
    {
        contact.Durum = true;
        contact.dateTime=DateTime.Now;
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }
    public async Task Solved(Contact contact)
    {
        var seciliContact = await _context.Contacts.FindAsync(contact.Id);
        seciliContact.Durum = false;
        await _context.SaveChangesAsync();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(Contact contact)
    {
        if (ModelState.IsValid) 
        {
            try
            {
               await _contactService.Ekle(contact);
                TempData["Mesaj"] = "Form gonderildi";
            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = "Bir hata olustu: " + ex.Message;
            }

            return RedirectToAction("Index"); 
        }
        return View(contact);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Contacts()
    {
        var contacts = await _contactService.GetTumContacts();
        var solvedContacts = await _contactService.GetSolvedContacts();
        ViewData["SolvedContacts"] = solvedContacts;

        return View(contacts);
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Solved(Contact contact)
    {
         await _contactService.Solved(contact);

        return RedirectToAction("Contacts", "Contact");
    }
    
}
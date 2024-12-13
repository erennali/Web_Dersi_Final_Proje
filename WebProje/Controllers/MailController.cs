using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;
[Authorize(Roles = "Admin")]
public class MailController : Controller
{
    private readonly IMailService _mailService;

    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Mail mail)
    {
        _mailService.Gonder(mail);
        return RedirectToAction("Index", "Mail");
    }
    
}
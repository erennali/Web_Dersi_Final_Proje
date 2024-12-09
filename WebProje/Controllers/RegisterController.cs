using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(Register register)
    {
        var appUser = new AppUser()
        {
            Name = register.Name,
            Surname = register.Surname,
            Email = register.Mail,
            UserName = register.Username
        };
        var result = await _userManager.CreateAsync(appUser, register.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }
        return View();
    }
}
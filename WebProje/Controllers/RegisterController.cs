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
    
    [HttpGet]
    public IActionResult AdminRegister()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AdminRegister(Register register)
    {
        var appUser2 = new AppUser()
        {
            Name = register.Name,
            Surname = register.Surname,
            Email = register.Mail,
            UserName = register.Username
        };
        var result = await _userManager.CreateAsync(appUser2, register.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("AdminMenu", "Urun");
        }
        return View();
    }

    public async Task<IActionResult> GetAdmins()
    {
        // Admin rolüne sahip tüm kullanıcıları almak
        var users = _userManager.Users.ToList();

        return View(users); 
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
    
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Login login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);
        //ilk false = kullanıcı hatırlansın mı ; ikinci false da kullanıcı şifreyi yanlış girdikçe değer artsın mı db de
        if (result.Succeeded)
        {
            RedirectToAction("Index", "Kategori");
        }
        return View();
    }
}
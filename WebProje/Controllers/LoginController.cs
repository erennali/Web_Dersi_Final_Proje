using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
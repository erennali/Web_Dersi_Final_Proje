using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers;

[AllowAnonymous]
public class AdminController : Controller
{
    
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AdminController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
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
            // Kullanıcıyı al
            var user = await _userManager.FindByNameAsync(login.Username);

            // Kullanıcının rollerini al
            var roles = await _userManager.GetRolesAsync(user);

            //kullanıcı admin rolündeyse, Admin sayfasına yönlendir
            if (roles.Contains("Admin"))
            {
                return RedirectToAction("AdminMenu", "Urun");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAdmins()
    {
        var admins = new List<AppUser>();
        var users =await _userManager.Users.ToListAsync();
        foreach (var user in users)
        {
             var roles = await _userManager.GetRolesAsync(user);
             if (roles.Contains("Admin"))
             {
                 admins.Add(user);
             }
             
        }
       
        
        return View(admins);
    }
}
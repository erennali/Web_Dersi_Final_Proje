using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.EfCore;
using WebProje.Models;
using WebProje.Services.Abstract;

namespace WebProje.Controllers;


//[AllowAnonymous]
public class AdminController : Controller
{
    
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IBasketService _basketService;
    private readonly WebDbContext _context;

    public AdminController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IBasketService basketService, WebDbContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _basketService = basketService;
        _context = context;
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
            var user = await _userManager.FindByNameAsync(login.Username);
            // kullanıcının rolü
            var roles = await _userManager.GetRolesAsync(user);

            //kullanıcı admin rolündeyse
            if (roles.Contains("Admin"))
            {
                return RedirectToAction("AdminGetBasket", "Admin");
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

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Admin");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AdminGetBasket()
    {
        var tumOrder = await _basketService.GetTumOrder();
        var baskets =  _basketService.GetTumOrder();

        ViewBag.BasketsWithMasaAdi = baskets;

        return View(tumOrder);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult AdminBasketSil(Guid masaId, string productName)
    {
        var basketItem = _context.Baskets
            .FirstOrDefault(b => b.MasaId == masaId && b.ProductName == productName);

        if (basketItem != null)
        {
            _context.Baskets.Remove(basketItem);  
            _context.SaveChanges();  
        }
        
        return RedirectToAction("AdminGetBasket");
    }
    public IActionResult Notifications()
    {
        return View();
    }
    
}
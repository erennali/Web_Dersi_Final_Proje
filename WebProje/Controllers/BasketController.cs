using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers;

public class BasketController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
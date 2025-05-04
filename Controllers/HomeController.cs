using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Cards()
    {
        return View();
    }

    public IActionResult Categorization()
    {
        return View();
    }

    public IActionResult Insights()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

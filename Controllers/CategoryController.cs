using Microsoft.AspNetCore.Mvc;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

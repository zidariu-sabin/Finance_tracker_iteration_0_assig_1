using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;
using finance_tracker_iteration_0_dotnet_mvc.Enums;


namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TransactionController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // List all cards for the current user
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var transactions = _context.Transactions.Where(c => c.UserId == user.Id).ToList();
            var categories = _context.Categories.Where(c => c.UserId == user.Id).ToList();
            var paymentMethods = _context.PaymentMethods.Where(c => c.UserId == user.Id).ToList();
            var locations = _context.Locations.Where(c => c.UserId == user.Id).ToList();

            foreach (var transaction in transactions)
            {
                if (transaction.CategoryId.HasValue)
                {
                    transaction.Category = categories.FirstOrDefault(c => c.Id == transaction.CategoryId);
                }
                if (transaction.PaymentMethodId.HasValue)
                {
                    transaction.PaymentMethod = paymentMethods.FirstOrDefault(c => c.Id == transaction.PaymentMethodId);
                }
                if (transaction.LocationId!=null)
                {
                    transaction.Location = locations.FirstOrDefault(c => c.Id == transaction.LocationId);
                }
            }
            return View(transactions);
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.Categories = _context.Categories.Where(c => c.UserId == user.Id).ToList();
            ViewBag.PaymentMethods = _context.PaymentMethods.Where(p => p.UserId == user.Id).ToList();
            ViewBag.Locations = _context.Locations.Where(l => l.UserId == user.Id).ToList();
            ViewBag.Currencies = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                transaction.UserId = user.Id;
                _context.Transactions.Add(transaction);
                // ViewBag.Currencies = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            // Repopulate dropdowns if model state is invalid
            ViewBag.Categories = _context.Categories.Where(c => c.UserId == user.Id).ToList();
            ViewBag.PaymentMethods = _context.PaymentMethods.Where(p => p.UserId == user.Id).ToList();
            ViewBag.Locations = _context.Locations.Where(l => l.UserId == user.Id).ToList();
            ViewBag.Currencies = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(transaction);
        }
    }
}
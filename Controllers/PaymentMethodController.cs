using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    [Authorize]
    public class PaymentMethodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PaymentMethodController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var paymentMethods = _context.PaymentMethods.Where(c => c.UserId == user.Id).ToList();
            var cards = _context.Cards.Where(c => c.UserId == user.Id).ToList();
            foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.CardId.HasValue)
                {
                    paymentMethod.Card = cards.FirstOrDefault(c => c.Id == paymentMethod.CardId);
                }
            }
            return View(paymentMethods);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null || paymentMethod.UserId != user.Id)
            {
                return NotFound();
            }
            _context.PaymentMethods.Remove(paymentMethod);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
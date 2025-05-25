using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CardController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // List all cards for the current user
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cards = _context.Cards.Where(c => c.UserId == user.Id).ToList();
            return View(cards);
        }

        // GET: Create
        public IActionResult Create() => View();

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Card card)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                card.UserId = user.Id;
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();
                var paymentMethod = new PaymentMethod
                {
                    Name = card.Holder + " Card",
                    Type = finance_tracker_iteration_0_dotnet_mvc.Enums.PaymentMethodType.Card,
                    UserId = user.Id,
                    CardId = card.Id
                };
                _context.PaymentMethods.Add(paymentMethod);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "PaymentMethod");

            }
            return View(card);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var card = await _context.Cards.FindAsync(id);
            if (card == null || card.UserId != user.Id)
                return NotFound();
            return View(card);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Card card)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id != card.Id || card.UserId != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                card.UserId = user.Id; // Ensure UserId is set
                _context.Update(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var card = await _context.Cards.FindAsync(id);
            if (card == null || card.UserId != user.Id)
                return NotFound();
            return View(card);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var card = await _context.Cards.FindAsync(id);
            var paymentMethod = _context.PaymentMethods.FirstOrDefault(pm => pm.CardId == id && pm.UserId == user.Id);
            if (paymentMethod != null && paymentMethod.UserId == user.Id){
                _context.PaymentMethods.Remove(paymentMethod);
            }
            if (card == null || card.UserId != user.Id)
                return NotFound();

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PaymentMethod");
        }
    }
}
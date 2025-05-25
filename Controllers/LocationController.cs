using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public LocationController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // List all cards for the current user
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var locations = _context.Locations.Where(c => c.UserId == user.Id).ToList();
            return View(locations);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            var user = await _userManager.GetUserAsync(User);
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))  
            {
                Console.WriteLine(error.ErrorMessage);
            }
            if (ModelState.IsValid)
            {
                location.UserId = user.Id;
                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Edit
        [HttpGet]
         public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var location = await _context.Locations.FindAsync(id);
            if (location == null || location.UserId != user.Id)
                return NotFound();
            return View(location);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Location location)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id != location.Id || location.UserId != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var location = await _context.Locations.FindAsync(id);
            if (location == null || location.UserId != user.Id)
                return NotFound();
            return View(location);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var location = await _context.Locations.FindAsync(id);
            if (location == null || location.UserId != user.Id)
                return NotFound();

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
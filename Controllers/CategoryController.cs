﻿using Microsoft.AspNetCore.Mvc;
using finance_tracker_iteration_0_dotnet_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace finance_tracker_iteration_0_dotnet_mvc.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CategoryController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // List all categories for the current user
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var categories = _context.Categories
                .Where(c => c.UserId == user.Id)
                .ToList();
            return View(categories);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                category.UserId = user.Id;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var category = await _context.Categories.FindAsync(id);
            if (category == null || category.UserId != user.Id)
                return NotFound();
            return View(category);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id != category.Id || category.UserId != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var category = await _context.Categories.FindAsync(id);
            if (category == null || category.UserId != user.Id)
                return NotFound();
            return View(category);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var category = await _context.Categories.FindAsync(id);
            if (category == null || category.UserId != user.Id)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
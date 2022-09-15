using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bootstrap2.Data;
using Bootstrap2.Models;

namespace Bootstrap2.Areas.ShopMgmt.Controllers
{
    [Area("ShopMgmt")]
    public class GroceriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopMgmt/Groceries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groceries.Include(b => b.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> GetGroceriesOfCategory(int filterCategoryId)
        {
            var viewmodel = await _context.Groceries
                                          .Where(b => b.CategoryId == filterCategoryId)
                                          .Include(b => b.Category)
                                          .ToListAsync();

            return View(viewName: "Index", model: viewmodel);
        }

        // GET: ShopMgmt/Groceries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Groceries
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.GroceryId == id);
            if (grocery == null)
            {
                return NotFound();
            }

            return View(grocery);
        }

        // GET: ShopMgmt/Groceries/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ShopMgmt/Groceries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroceryId,GroceryName,NumberOfItems,GroceryPrice,CategoryId")] Grocery grocery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grocery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", grocery.CategoryId);
            return View(grocery);
        }

        // GET: ShopMgmt/Groceries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Groceries.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", grocery.CategoryId);
            return View(grocery);
        }

        // POST: ShopMgmt/Groceries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroceryId,GroceryName,NumberOfItems,GroceryPrice,CategoryId")] Grocery grocery)
        {
            if (id != grocery.GroceryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grocery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryExists(grocery.GroceryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", grocery.CategoryId);
            return View(grocery);
        }

        // GET: ShopMgmt/Groceries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Groceries
                .Include(g => g.Category)
                .FirstOrDefaultAsync(m => m.GroceryId == id);
            if (grocery == null)
            {
                return NotFound();
            }

            return View(grocery);
        }

        // POST: ShopMgmt/Groceries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grocery = await _context.Groceries.FindAsync(id);
            _context.Groceries.Remove(grocery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryExists(int id)
        {
            return _context.Groceries.Any(e => e.GroceryId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant1.Data;
using Restaurant1.Models;

namespace Restaurant1.Areas.RestMgmt.Controllers
{
    [Area("RestMgmt")]
    public class OrderrsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderrsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestMgmt/Orderrs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orderr.Include(o => o.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RestMgmt/Orderrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderr = await _context.Orderr
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderr == null)
            {
                return NotFound();
            }

            return View(orderr);
        }

        // GET: RestMgmt/Orderrs/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail");
            return View();
        }

        // POST: RestMgmt/Orderrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderName,OrderStatus,OrderDate,CustomerId")] Orderr orderr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderr.CustomerId);
            return View(orderr);
        }

        // GET: RestMgmt/Orderrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderr = await _context.Orderr.FindAsync(id);
            if (orderr == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderr.CustomerId);
            return View(orderr);
        }

        // POST: RestMgmt/Orderrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderName,OrderStatus,OrderDate,CustomerId")] Orderr orderr)
        {
            if (id != orderr.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderrExists(orderr.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderr.CustomerId);
            return View(orderr);
        }

        // GET: RestMgmt/Orderrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderr = await _context.Orderr
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderr == null)
            {
                return NotFound();
            }

            return View(orderr);
        }

        // POST: RestMgmt/Orderrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderr = await _context.Orderr.FindAsync(id);
            _context.Orderr.Remove(orderr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderrExists(int id)
        {
            return _context.Orderr.Any(e => e.OrderId == id);
        }
    }
}

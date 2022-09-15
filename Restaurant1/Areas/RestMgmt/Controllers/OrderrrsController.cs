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
    public class OrderrrsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderrrsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestMgmt/Orderrrs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orderrr.Include(o => o.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RestMgmt/Orderrrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderrr = await _context.Orderrr
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderrr == null)
            {
                return NotFound();
            }

            return View(orderrr);
        }

        // GET: RestMgmt/Orderrrs/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail");
            return View();
        }

        // POST: RestMgmt/Orderrrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderName,OrderStatus,OrderDate,OrderItems,OrderAmount,CustomerId")] Orderrr orderrr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderrr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderrr.CustomerId);
            return View(orderrr);
        }

        // GET: RestMgmt/Orderrrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderrr = await _context.Orderrr.FindAsync(id);
            if (orderrr == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderrr.CustomerId);
            return View(orderrr);
        }

        // POST: RestMgmt/Orderrrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderName,OrderStatus,OrderDate,OrderItems,OrderAmount,CustomerId")] Orderrr orderrr)
        {
            if (id != orderrr.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderrr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderrrExists(orderrr.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", orderrr.CustomerId);
            return View(orderrr);
        }

        // GET: RestMgmt/Orderrrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderrr = await _context.Orderrr
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderrr == null)
            {
                return NotFound();
            }

            return View(orderrr);
        }

        // POST: RestMgmt/Orderrrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderrr = await _context.Orderrr.FindAsync(id);
            _context.Orderrr.Remove(orderrr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderrrExists(int id)
        {
            return _context.Orderrr.Any(e => e.OrderId == id);
        }
    }
}

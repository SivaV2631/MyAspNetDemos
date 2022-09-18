using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.RestMgmt.Controllers
{
    [Area("RestMgmt")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestMgmt/Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.Item).Include(o => o.Payment).Include(o => o.Table);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RestMgmt/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .Include(o => o.Payment)
                .Include(o => o.Table)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: RestMgmt/Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail");
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentType");
            ViewData["TableId"] = new SelectList(_context.Tables, "TableId", "TableId");
            return View();
        }

        // POST: RestMgmt/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderType,OrderDate,OrderAmount,TermsandConditions,ItemId,PaymentId,CustomerId,TableId")] Order order)
        {

                if (ModelState.IsValid)
                {
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", order.CustomerId);
                ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", order.ItemId);
                ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentType", order.PaymentId);
                ViewData["TableId"] = new SelectList(_context.Tables, "TableId", "TableId", order.TableId);
                return View(order);
        }

        // GET: RestMgmt/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", order.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", order.ItemId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentType", order.PaymentId);
            ViewData["TableId"] = new SelectList(_context.Tables, "TableId", "TableId", order.TableId);
            return View(order);
        }

        // POST: RestMgmt/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderType,OrderDate,OrderAmount,TermsandConditions,ItemId,PaymentId,CustomerId,TableId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", order.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemName", order.ItemId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentType", order.PaymentId);
            ViewData["TableId"] = new SelectList(_context.Tables, "TableId", "TableId", order.TableId);
            return View(order);
        }

        // GET: RestMgmt/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Item)
                .Include(o => o.Payment)
                .Include(o => o.Table)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: RestMgmt/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}

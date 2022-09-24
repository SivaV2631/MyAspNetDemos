using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.Models;

namespace JobPortal.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class EventTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/EventTables
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventTables.Include(e => e.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/EventTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTable = await _context.EventTables
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.EventTableId == id);
            if (eventTable == null)
            {
                return NotFound();
            }

            return View(eventTable);
        }

        // GET: PortalMgmt/EventTables/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: PortalMgmt/EventTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTableId,EventTitle,EventDate,CompanyId,Location,StartDate,EndDate,EventContactDetails,Description,EventBanner")] EventTable eventTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", eventTable.CompanyId);
            return View(eventTable);
        }

        // GET: PortalMgmt/EventTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTable = await _context.EventTables.FindAsync(id);
            if (eventTable == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", eventTable.CompanyId);
            return View(eventTable);
        }

        // POST: PortalMgmt/EventTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTableId,EventTitle,EventDate,CompanyId,Location,StartDate,EndDate,EventContactDetails,Description,EventBanner")] EventTable eventTable)
        {
            if (id != eventTable.EventTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTableExists(eventTable.EventTableId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", eventTable.CompanyId);
            return View(eventTable);
        }

        // GET: PortalMgmt/EventTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTable = await _context.EventTables
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.EventTableId == id);
            if (eventTable == null)
            {
                return NotFound();
            }

            return View(eventTable);
        }

        // POST: PortalMgmt/EventTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventTable = await _context.EventTables.FindAsync(id);
            _context.EventTables.Remove(eventTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTableExists(int id)
        {
            return _context.EventTables.Any(e => e.EventTableId == id);
        }
    }
}

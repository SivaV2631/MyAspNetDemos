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
    public class CurrentJobStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrentJobStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/CurrentJobStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurrentJobStatuses.ToListAsync());
        }

        // GET: PortalMgmt/CurrentJobStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentJobStatus = await _context.CurrentJobStatuses
                .FirstOrDefaultAsync(m => m.CurrentJobStatusId == id);
            if (currentJobStatus == null)
            {
                return NotFound();
            }

            return View(currentJobStatus);
        }

        // GET: PortalMgmt/CurrentJobStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalMgmt/CurrentJobStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrentJobStatusId,CurrentJobStatusName")] CurrentJobStatus currentJobStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentJobStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentJobStatus);
        }

        // GET: PortalMgmt/CurrentJobStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentJobStatus = await _context.CurrentJobStatuses.FindAsync(id);
            if (currentJobStatus == null)
            {
                return NotFound();
            }
            return View(currentJobStatus);
        }

        // POST: PortalMgmt/CurrentJobStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurrentJobStatusId,CurrentJobStatusName")] CurrentJobStatus currentJobStatus)
        {
            if (id != currentJobStatus.CurrentJobStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentJobStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentJobStatusExists(currentJobStatus.CurrentJobStatusId))
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
            return View(currentJobStatus);
        }

        // GET: PortalMgmt/CurrentJobStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentJobStatus = await _context.CurrentJobStatuses
                .FirstOrDefaultAsync(m => m.CurrentJobStatusId == id);
            if (currentJobStatus == null)
            {
                return NotFound();
            }

            return View(currentJobStatus);
        }

        // POST: PortalMgmt/CurrentJobStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentJobStatus = await _context.CurrentJobStatuses.FindAsync(id);
            _context.CurrentJobStatuses.Remove(currentJobStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentJobStatusExists(int id)
        {
            return _context.CurrentJobStatuses.Any(e => e.CurrentJobStatusId == id);
        }
    }
}

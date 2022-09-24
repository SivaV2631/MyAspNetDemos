using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyJobPortal.Data;
using MyJobPortal.Models;

namespace MyJobPortal.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class AccountStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/AccountStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountStatuses.ToListAsync());
        }

        // GET: PortalMgmt/AccountStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses
                .FirstOrDefaultAsync(m => m.AccountStatusId == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // GET: PortalMgmt/AccountStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalMgmt/AccountStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountStatusId,AccountStatusName")] AccountStatus accountStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountStatus);
        }

        // GET: PortalMgmt/AccountStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses.FindAsync(id);
            if (accountStatus == null)
            {
                return NotFound();
            }
            return View(accountStatus);
        }

        // POST: PortalMgmt/AccountStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountStatusId,AccountStatusName")] AccountStatus accountStatus)
        {
            if (id != accountStatus.AccountStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountStatusExists(accountStatus.AccountStatusId))
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
            return View(accountStatus);
        }

        // GET: PortalMgmt/AccountStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses
                .FirstOrDefaultAsync(m => m.AccountStatusId == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // POST: PortalMgmt/AccountStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountStatus = await _context.AccountStatuses.FindAsync(id);
            _context.AccountStatuses.Remove(accountStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountStatusExists(int id)
        {
            return _context.AccountStatuses.Any(e => e.AccountStatusId == id);
        }
    }
}

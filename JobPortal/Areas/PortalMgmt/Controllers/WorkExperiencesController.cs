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
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/WorkExperiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkExperiences.Include(w => w.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Country)
                .FirstOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: PortalMgmt/WorkExperiences/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: PortalMgmt/WorkExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkExperienceId,Company,Title,CountryId,FromYear,ToYear")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", workExperience.CountryId);
            return View(workExperience);
        }

        // GET: PortalMgmt/WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", workExperience.CountryId);
            return View(workExperience);
        }

        // POST: PortalMgmt/WorkExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkExperienceId,Company,Title,CountryId,FromYear,ToYear")] WorkExperience workExperience)
        {
            if (id != workExperience.WorkExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.WorkExperienceId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", workExperience.CountryId);
            return View(workExperience);
        }

        // GET: PortalMgmt/WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperiences
                .Include(w => w.Country)
                .FirstOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: PortalMgmt/WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperiences.Any(e => e.WorkExperienceId == id);
        }
    }
}

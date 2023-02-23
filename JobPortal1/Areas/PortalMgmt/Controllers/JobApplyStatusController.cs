using JobPortal1.Data;
using JobPortal1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal1.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class JobApplyStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplyStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/JobApplyStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplyStatuses.ToListAsync());
        }

        // GET: PortalMgmt/JobApplyStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplyStatus = await _context.JobApplyStatuses
                .FirstOrDefaultAsync(m => m.JobApplyStatusId == id);
            if (jobApplyStatus == null)
            {
                return NotFound();
            }

            return View(jobApplyStatus);
        }

        // GET: PortalMgmt/JobApplyStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalMgmt/JobApplyStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobApplyStatusId,JobApplyStatusName")] JobApplyStatus jobApplyStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplyStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplyStatus);
        }

        // GET: PortalMgmt/JobApplyStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplyStatus = await _context.JobApplyStatuses.FindAsync(id);
            if (jobApplyStatus == null)
            {
                return NotFound();
            }
            return View(jobApplyStatus);
        }

        // POST: PortalMgmt/JobApplyStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobApplyStatusId,JobApplyStatusName")] JobApplyStatus jobApplyStatus)
        {
            if (id != jobApplyStatus.JobApplyStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplyStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplyStatusExists(jobApplyStatus.JobApplyStatusId))
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
            return View(jobApplyStatus);
        }

        // GET: PortalMgmt/JobApplyStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplyStatus = await _context.JobApplyStatuses
                .FirstOrDefaultAsync(m => m.JobApplyStatusId == id);
            if (jobApplyStatus == null)
            {
                return NotFound();
            }

            return View(jobApplyStatus);
        }

        // POST: PortalMgmt/JobApplyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplyStatus = await _context.JobApplyStatuses.FindAsync(id);
            _context.JobApplyStatuses.Remove(jobApplyStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplyStatusExists(int id)
        {
            return _context.JobApplyStatuses.Any(e => e.JobApplyStatusId == id);
        }
    }
}

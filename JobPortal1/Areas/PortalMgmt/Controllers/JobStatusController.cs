using JobPortal1.Data;
using JobPortal1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal1.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class JobStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/JobStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobStatuses.ToListAsync());
        }

        // GET: PortalMgmt/JobStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatuses
                .FirstOrDefaultAsync(m => m.JobStatusId == id);
            if (jobStatus == null)
            {
                return NotFound();
            }

            return View(jobStatus);
        }

        // GET: PortalMgmt/JobStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalMgmt/JobStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobStatusId,JobStatusName,StatusMessage")] JobStatus jobStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobStatus);
        }

        // GET: PortalMgmt/JobStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatuses.FindAsync(id);
            if (jobStatus == null)
            {
                return NotFound();
            }
            return View(jobStatus);
        }

        // POST: PortalMgmt/JobStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobStatusId,JobStatusName,StatusMessage")] JobStatus jobStatus)
        {
            if (id != jobStatus.JobStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobStatusExists(jobStatus.JobStatusId))
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
            return View(jobStatus);
        }

        // GET: PortalMgmt/JobStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatuses
                .FirstOrDefaultAsync(m => m.JobStatusId == id);
            if (jobStatus == null)
            {
                return NotFound();
            }

            return View(jobStatus);
        }

        // POST: PortalMgmt/JobStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobStatus = await _context.JobStatuses.FindAsync(id);
            _context.JobStatuses.Remove(jobStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobStatusExists(int id)
        {
            return _context.JobStatuses.Any(e => e.JobStatusId == id);
        }
    }
}

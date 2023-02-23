using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.Models;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class ApplyJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplyJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/ApplyJobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplyJobs.Include(a => a.Company).Include(a => a.JobCategory).Include(a => a.JobNature).Include(a => a.JobStatus).Include(a => a.PostJob).Include(a => a.UserTable);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/ApplyJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyJob = await _context.ApplyJobs
                .Include(a => a.Company)
                .Include(a => a.JobCategory)
                .Include(a => a.JobNature)
                .Include(a => a.JobStatus)
                .Include(a => a.PostJob)
                .Include(a => a.UserTable)
                .FirstOrDefaultAsync(m => m.ApplyJobId == id);
            if (applyJob == null)
            {
                return NotFound();
            }

            return View(applyJob);
        }

        // GET: PortalMgmt/ApplyJobs/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName");
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName");
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName");
            ViewData["PostJobId"] = new SelectList(_context.PostJobs, "PostJobId", "JobTitle");
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo");
            return View();
        }

        // POST: PortalMgmt/ApplyJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplyJobId,ApplicantName,UserId,ContactNo,Email,AppliedAt,CompanyId,JobNatureId,JobCategoryId,JobStatusId,PostJobId")] ApplyJob applyJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applyJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", applyJob.CompanyId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", applyJob.JobCategoryId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", applyJob.JobNatureId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", applyJob.JobStatusId);
            ViewData["PostJobId"] = new SelectList(_context.PostJobs, "PostJobId", "JobTitle", applyJob.PostJobId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", applyJob.UserId);
            return View(applyJob);
        }

        // GET: PortalMgmt/ApplyJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyJob = await _context.ApplyJobs.FindAsync(id);
            if (applyJob == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", applyJob.CompanyId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", applyJob.JobCategoryId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", applyJob.JobNatureId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", applyJob.JobStatusId);
            ViewData["PostJobId"] = new SelectList(_context.PostJobs, "PostJobId", "JobTitle", applyJob.PostJobId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", applyJob.UserId);
            return View(applyJob);
        }

        // POST: PortalMgmt/ApplyJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplyJobId,ApplicantName,UserId,ContactNo,Email,AppliedAt,CompanyId,JobNatureId,JobCategoryId,JobStatusId,PostJobId")] ApplyJob applyJob)
        {
            if (id != applyJob.ApplyJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applyJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplyJobExists(applyJob.ApplyJobId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", applyJob.CompanyId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", applyJob.JobCategoryId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", applyJob.JobNatureId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", applyJob.JobStatusId);
            ViewData["PostJobId"] = new SelectList(_context.PostJobs, "PostJobId", "JobTitle", applyJob.PostJobId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", applyJob.UserId);
            return View(applyJob);
        }

        // GET: PortalMgmt/ApplyJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applyJob = await _context.ApplyJobs
                .Include(a => a.Company)
                .Include(a => a.JobCategory)
                .Include(a => a.JobNature)
                .Include(a => a.JobStatus)
                .Include(a => a.PostJob)
                .Include(a => a.UserTable)
                .FirstOrDefaultAsync(m => m.ApplyJobId == id);
            if (applyJob == null)
            {
                return NotFound();
            }

            return View(applyJob);
        }

        // POST: PortalMgmt/ApplyJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applyJob = await _context.ApplyJobs.FindAsync(id);
            _context.ApplyJobs.Remove(applyJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplyJobExists(int id)
        {
            return _context.ApplyJobs.Any(e => e.ApplyJobId == id);
        }
    }
}

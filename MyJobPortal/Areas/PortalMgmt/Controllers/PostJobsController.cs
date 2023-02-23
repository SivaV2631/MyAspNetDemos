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
    public class PostJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/PostJobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PostJobs.Include(p => p.Company).Include(p => p.JobNature).Include(p => p.JobRequirement).Include(p => p.JobStatus).Include(p => p.UserTable);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/PostJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postJob = await _context.PostJobs
                .Include(p => p.Company)
                .Include(p => p.JobNature)
                .Include(p => p.JobRequirement)
                .Include(p => p.JobStatus)
                .Include(p => p.UserTable)
                .FirstOrDefaultAsync(m => m.PostJobId == id);
            if (postJob == null)
            {
                return NotFound();
            }

            return View(postJob);
        }

        // GET: PortalMgmt/PostJobs/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName");
            ViewData["JoRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle");
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName");
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo");
            return View();
        }

        // POST: PortalMgmt/PostJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostJobId,CompanyId,JobTitle,Vacancies,PostCreatedAt,LastDate,Qualification,MinSalary,MaxSalary,Location,WebUrl,JoRequirementId,JobStatusId,JobDescription,JobNatureId,UserId")] PostJob postJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", postJob.CompanyId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", postJob.JobNatureId);
            ViewData["JoRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", postJob.JoRequirementId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", postJob.JobStatusId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", postJob.UserId);
            return View(postJob);
        }

        // GET: PortalMgmt/PostJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postJob = await _context.PostJobs.FindAsync(id);
            if (postJob == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", postJob.CompanyId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", postJob.JobNatureId);
            ViewData["JoRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", postJob.JoRequirementId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", postJob.JobStatusId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", postJob.UserId);
            return View(postJob);
        }

        // POST: PortalMgmt/PostJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostJobId,CompanyId,JobTitle,Vacancies,PostCreatedAt,LastDate,Qualification,MinSalary,MaxSalary,Location,WebUrl,JoRequirementId,JobStatusId,JobDescription,JobNatureId,UserId")] PostJob postJob)
        {
            if (id != postJob.PostJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostJobExists(postJob.PostJobId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", postJob.CompanyId);
            ViewData["JobNatureId"] = new SelectList(_context.JobNatures, "JobNatureId", "JobNatureName", postJob.JobNatureId);
            ViewData["JoRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", postJob.JoRequirementId);
            ViewData["JobStatusId"] = new SelectList(_context.JobStatuses, "JobStatusId", "JobStatusName", postJob.JobStatusId);
            ViewData["UserId"] = new SelectList(_context.UserTables, "UserId", "ContactNo", postJob.UserId);
            return View(postJob);
        }

        // GET: PortalMgmt/PostJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postJob = await _context.PostJobs
                .Include(p => p.Company)
                .Include(p => p.JobNature)
                .Include(p => p.JobRequirement)
                .Include(p => p.JobStatus)
                .Include(p => p.UserTable)
                .FirstOrDefaultAsync(m => m.PostJobId == id);
            if (postJob == null)
            {
                return NotFound();
            }

            return View(postJob);
        }

        // POST: PortalMgmt/PostJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postJob = await _context.PostJobs.FindAsync(id);
            _context.PostJobs.Remove(postJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostJobExists(int id)
        {
            return _context.PostJobs.Any(e => e.PostJobId == id);
        }
    }
}

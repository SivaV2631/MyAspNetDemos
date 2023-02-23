using JobPortal1.Data;
using JobPortal1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal1.Areas.PortalMgmt.Controllers
{
    [Area("PortalMgmt")]
    public class JobRequirementDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobRequirementDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/JobRequirementDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobRequirementsDetails.Include(j => j.JobRequirement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/JobRequirementDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRequirementDetail = await _context.JobRequirementsDetails
                .Include(j => j.JobRequirement)
                .FirstOrDefaultAsync(m => m.JobRequirementDetailId == id);
            if (jobRequirementDetail == null)
            {
                return NotFound();
            }

            return View(jobRequirementDetail);
        }

        // GET: PortalMgmt/JobRequirementDetails/Create
        public IActionResult Create()
        {
            ViewData["JobRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle");
            return View();
        }

        // POST: PortalMgmt/JobRequirementDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobRequirementDetailId,JobRequirmentDetailName,JobRequirementId")] JobRequirementDetail jobRequirementDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobRequirementDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", jobRequirementDetail.JobRequirementId);
            return View(jobRequirementDetail);
        }

        // GET: PortalMgmt/JobRequirementDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRequirementDetail = await _context.JobRequirementsDetails.FindAsync(id);
            if (jobRequirementDetail == null)
            {
                return NotFound();
            }
            ViewData["JobRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", jobRequirementDetail.JobRequirementId);
            return View(jobRequirementDetail);
        }

        // POST: PortalMgmt/JobRequirementDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobRequirementDetailId,JobRequirmentDetailName,JobRequirementId")] JobRequirementDetail jobRequirementDetail)
        {
            if (id != jobRequirementDetail.JobRequirementDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobRequirementDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobRequirementDetailExists(jobRequirementDetail.JobRequirementDetailId))
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
            ViewData["JobRequirementId"] = new SelectList(_context.JobRequirements, "JobRequirementId", "JobRequirementTitle", jobRequirementDetail.JobRequirementId);
            return View(jobRequirementDetail);
        }

        // GET: PortalMgmt/JobRequirementDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobRequirementDetail = await _context.JobRequirementsDetails
                .Include(j => j.JobRequirement)
                .FirstOrDefaultAsync(m => m.JobRequirementDetailId == id);
            if (jobRequirementDetail == null)
            {
                return NotFound();
            }

            return View(jobRequirementDetail);
        }

        // POST: PortalMgmt/JobRequirementDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobRequirementDetail = await _context.JobRequirementsDetails.FindAsync(id);
            _context.JobRequirementsDetails.Remove(jobRequirementDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobRequirementDetailExists(int id)
        {
            return _context.JobRequirementsDetails.Any(e => e.JobRequirementDetailId == id);
        }
    }
}

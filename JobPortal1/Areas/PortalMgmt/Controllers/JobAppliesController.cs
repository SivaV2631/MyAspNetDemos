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
    public class JobAppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobAppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/JobApplies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobApplies.Include(j => j.Employee).Include(j => j.JobApplyStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/JobApplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies
                .Include(j => j.Employee)
                .Include(j => j.JobApplyStatus)
                .FirstOrDefaultAsync(m => m.JobApplyId == id);
            if (jobApply == null)
            {
                return NotFound();
            }

            return View(jobApply);
        }

        // GET: PortalMgmt/JobApplies/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmailAddress");
            ViewData["JobApplyStatusId"] = new SelectList(_context.JobApplyStatuses, "JobApplyStatusId", "JobApplyStatusName");
            return View();
        }

        // POST: PortalMgmt/JobApplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobApplyId,JobApplyDateTime,JobApplyStatusUpdateDate,JobApplyStatusUpdate,JobApplyStatusId,EmployeeId")] JobApply jobApply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmailAddress", jobApply.EmployeeId);
            ViewData["JobApplyStatusId"] = new SelectList(_context.JobApplyStatuses, "JobApplyStatusId", "JobApplyStatusName", jobApply.JobApplyStatusId);
            return View(jobApply);
        }

        // GET: PortalMgmt/JobApplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies.FindAsync(id);
            if (jobApply == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmailAddress", jobApply.EmployeeId);
            ViewData["JobApplyStatusId"] = new SelectList(_context.JobApplyStatuses, "JobApplyStatusId", "JobApplyStatusName", jobApply.JobApplyStatusId);
            return View(jobApply);
        }

        // POST: PortalMgmt/JobApplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobApplyId,JobApplyDateTime,JobApplyStatusUpdateDate,JobApplyStatusUpdate,JobApplyStatusId,EmployeeId")] JobApply jobApply)
        {
            if (id != jobApply.JobApplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplyExists(jobApply.JobApplyId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmailAddress", jobApply.EmployeeId);
            ViewData["JobApplyStatusId"] = new SelectList(_context.JobApplyStatuses, "JobApplyStatusId", "JobApplyStatusName", jobApply.JobApplyStatusId);
            return View(jobApply);
        }

        // GET: PortalMgmt/JobApplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApply = await _context.JobApplies
                .Include(j => j.Employee)
                .Include(j => j.JobApplyStatus)
                .FirstOrDefaultAsync(m => m.JobApplyId == id);
            if (jobApply == null)
            {
                return NotFound();
            }

            return View(jobApply);
        }

        // POST: PortalMgmt/JobApplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApply = await _context.JobApplies.FindAsync(id);
            _context.JobApplies.Remove(jobApply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplyExists(int id)
        {
            return _context.JobApplies.Any(e => e.JobApplyId == id);
        }
    }
}

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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PortalMgmt/Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.Country).Include(e => e.JobCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PortalMgmt/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Country)
                .Include(e => e.JobCategory)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: PortalMgmt/Employees/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName");
            return View();
        }

        // POST: PortalMgmt/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,DOB,EmployeeAge,FatherName,EmailAddress,Gender,Photo,Qualification,PermanentAddress,AttachCV,JobReferences,Description,JobCategoryId,CountryId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", employee.CountryId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", employee.JobCategoryId);
            return View(employee);
        }

        // GET: PortalMgmt/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", employee.CountryId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", employee.JobCategoryId);
            return View(employee);
        }

        // POST: PortalMgmt/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeName,DOB,EmployeeAge,FatherName,EmailAddress,Gender,Photo,Qualification,PermanentAddress,AttachCV,JobReferences,Description,JobCategoryId,CountryId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName", employee.CountryId);
            ViewData["JobCategoryId"] = new SelectList(_context.JobCategories, "JobCategoryId", "JobCategoryName", employee.JobCategoryId);
            return View(employee);
        }

        // GET: PortalMgmt/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Country)
                .Include(e => e.JobCategory)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: PortalMgmt/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkExperience>>> GetWorkExperiences()
        {
            return await _context.WorkExperiences.ToListAsync();
        }

        // GET: api/WorkExperiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperience>> GetWorkExperience(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return workExperience;
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience(int id, WorkExperience workExperience)
        {
            if (id != workExperience.WorkExperienceId)
            {
                return BadRequest();
            }

            _context.Entry(workExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExperienceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkExperience>> PostWorkExperience(WorkExperience workExperience)
        {
            _context.WorkExperiences.Add(workExperience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkExperience", new { id = workExperience.WorkExperienceId }, workExperience);
        }

        // DELETE: api/WorkExperiences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkExperience>> DeleteWorkExperience(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();

            return workExperience;
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperiences.Any(e => e.WorkExperienceId == id);
        }
    }
}

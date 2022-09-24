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
    public class JobAppliesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobAppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobApplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApply>>> GetJobApplies()
        {
            return await _context.JobApplies.ToListAsync();
        }

        // GET: api/JobApplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApply>> GetJobApply(int id)
        {
            var jobApply = await _context.JobApplies.FindAsync(id);

            if (jobApply == null)
            {
                return NotFound();
            }

            return jobApply;
        }

        // PUT: api/JobApplies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobApply(int id, JobApply jobApply)
        {
            if (id != jobApply.JobApplyId)
            {
                return BadRequest();
            }

            _context.Entry(jobApply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplyExists(id))
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

        // POST: api/JobApplies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobApply>> PostJobApply(JobApply jobApply)
        {
            _context.JobApplies.Add(jobApply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobApply", new { id = jobApply.JobApplyId }, jobApply);
        }

        // DELETE: api/JobApplies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobApply>> DeleteJobApply(int id)
        {
            var jobApply = await _context.JobApplies.FindAsync(id);
            if (jobApply == null)
            {
                return NotFound();
            }

            _context.JobApplies.Remove(jobApply);
            await _context.SaveChangesAsync();

            return jobApply;
        }

        private bool JobApplyExists(int id)
        {
            return _context.JobApplies.Any(e => e.JobApplyId == id);
        }
    }
}

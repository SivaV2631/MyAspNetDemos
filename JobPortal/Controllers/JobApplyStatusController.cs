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
    public class JobApplyStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobApplyStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobApplyStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplyStatus>>> GetJobApplyStatuses()
        {
            return await _context.JobApplyStatuses.ToListAsync();
        }

        // GET: api/JobApplyStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplyStatus>> GetJobApplyStatus(int id)
        {
            var jobApplyStatus = await _context.JobApplyStatuses.FindAsync(id);

            if (jobApplyStatus == null)
            {
                return NotFound();
            }

            return jobApplyStatus;
        }

        // PUT: api/JobApplyStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobApplyStatus(int id, JobApplyStatus jobApplyStatus)
        {
            if (id != jobApplyStatus.JobApplyStatusId)
            {
                return BadRequest();
            }

            _context.Entry(jobApplyStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplyStatusExists(id))
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

        // POST: api/JobApplyStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobApplyStatus>> PostJobApplyStatus(JobApplyStatus jobApplyStatus)
        {
            _context.JobApplyStatuses.Add(jobApplyStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobApplyStatus", new { id = jobApplyStatus.JobApplyStatusId }, jobApplyStatus);
        }

        // DELETE: api/JobApplyStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobApplyStatus>> DeleteJobApplyStatus(int id)
        {
            var jobApplyStatus = await _context.JobApplyStatuses.FindAsync(id);
            if (jobApplyStatus == null)
            {
                return NotFound();
            }

            _context.JobApplyStatuses.Remove(jobApplyStatus);
            await _context.SaveChangesAsync();

            return jobApplyStatus;
        }

        private bool JobApplyStatusExists(int id)
        {
            return _context.JobApplyStatuses.Any(e => e.JobApplyStatusId == id);
        }
    }
}

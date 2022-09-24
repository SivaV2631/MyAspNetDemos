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
    public class CurrentJobStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrentJobStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrentJobStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentJobStatus>>> GetCurrentJobStatuses()
        {
            return await _context.CurrentJobStatuses.ToListAsync();
        }

        // GET: api/CurrentJobStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentJobStatus>> GetCurrentJobStatus(int id)
        {
            var currentJobStatus = await _context.CurrentJobStatuses.FindAsync(id);

            if (currentJobStatus == null)
            {
                return NotFound();
            }

            return currentJobStatus;
        }

        // PUT: api/CurrentJobStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentJobStatus(int id, CurrentJobStatus currentJobStatus)
        {
            if (id != currentJobStatus.CurrentJobStatusId)
            {
                return BadRequest();
            }

            _context.Entry(currentJobStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentJobStatusExists(id))
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

        // POST: api/CurrentJobStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CurrentJobStatus>> PostCurrentJobStatus(CurrentJobStatus currentJobStatus)
        {
            _context.CurrentJobStatuses.Add(currentJobStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrentJobStatus", new { id = currentJobStatus.CurrentJobStatusId }, currentJobStatus);
        }

        // DELETE: api/CurrentJobStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrentJobStatus>> DeleteCurrentJobStatus(int id)
        {
            var currentJobStatus = await _context.CurrentJobStatuses.FindAsync(id);
            if (currentJobStatus == null)
            {
                return NotFound();
            }

            _context.CurrentJobStatuses.Remove(currentJobStatus);
            await _context.SaveChangesAsync();

            return currentJobStatus;
        }

        private bool CurrentJobStatusExists(int id)
        {
            return _context.CurrentJobStatuses.Any(e => e.CurrentJobStatusId == id);
        }
    }
}

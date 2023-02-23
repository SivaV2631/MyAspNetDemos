using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobRequirementDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobRequirementDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobRequirementDetail>>> GetJobRequirementsDetails()
        {
            return await _context.JobRequirementsDetails.ToListAsync();
        }

        // GET: api/JobRequirementDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobRequirementDetail>> GetJobRequirementDetail(int id)
        {
            var jobRequirementDetail = await _context.JobRequirementsDetails.FindAsync(id);

            if (jobRequirementDetail == null)
            {
                return NotFound();
            }

            return jobRequirementDetail;
        }

        // PUT: api/JobRequirementDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobRequirementDetail(int id, JobRequirementDetail jobRequirementDetail)
        {
            if (id != jobRequirementDetail.JobRequirementDetailId)
            {
                return BadRequest();
            }

            _context.Entry(jobRequirementDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobRequirementDetailExists(id))
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

        // POST: api/JobRequirementDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobRequirementDetail>> PostJobRequirementDetail(JobRequirementDetail jobRequirementDetail)
        {
            _context.JobRequirementsDetails.Add(jobRequirementDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobRequirementDetail", new { id = jobRequirementDetail.JobRequirementDetailId }, jobRequirementDetail);
        }

        // DELETE: api/JobRequirementDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobRequirementDetail>> DeleteJobRequirementDetail(int id)
        {
            var jobRequirementDetail = await _context.JobRequirementsDetails.FindAsync(id);
            if (jobRequirementDetail == null)
            {
                return NotFound();
            }

            _context.JobRequirementsDetails.Remove(jobRequirementDetail);
            await _context.SaveChangesAsync();

            return jobRequirementDetail;
        }

        private bool JobRequirementDetailExists(int id)
        {
            return _context.JobRequirementsDetails.Any(e => e.JobRequirementDetailId == id);
        }
    }
}

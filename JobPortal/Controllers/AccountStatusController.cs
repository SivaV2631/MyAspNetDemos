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
    public class AccountStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AccountStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountStatus>>> GetAccountStatuses()
        {
            return await _context.AccountStatuses.ToListAsync();
        }

        // GET: api/AccountStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountStatus>> GetAccountStatus(int id)
        {
            var accountStatus = await _context.AccountStatuses.FindAsync(id);

            if (accountStatus == null)
            {
                return NotFound();
            }

            return accountStatus;
        }

        // PUT: api/AccountStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountStatus(int id, AccountStatus accountStatus)
        {
            if (id != accountStatus.AccountStatusId)
            {
                return BadRequest();
            }

            _context.Entry(accountStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountStatusExists(id))
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

        // POST: api/AccountStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountStatus>> PostAccountStatus(AccountStatus accountStatus)
        {
            _context.AccountStatuses.Add(accountStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountStatus", new { id = accountStatus.AccountStatusId }, accountStatus);
        }

        // DELETE: api/AccountStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountStatus>> DeleteAccountStatus(int id)
        {
            var accountStatus = await _context.AccountStatuses.FindAsync(id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            _context.AccountStatuses.Remove(accountStatus);
            await _context.SaveChangesAsync();

            return accountStatus;
        }

        private bool AccountStatusExists(int id)
        {
            return _context.AccountStatuses.Any(e => e.AccountStatusId == id);
        }
    }
}

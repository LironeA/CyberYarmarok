using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberYarmarok.Models;

namespace CyberYarmarok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FairsController : ControllerBase
    {
        private readonly CyberYarmarokContext _context;

        public FairsController(CyberYarmarokContext context)
        {
            _context = context;
        }

        // GET: api/Fairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fair>>> GetFairs()
        {
          if (_context.Fairs == null)
          {
              return NotFound();
          }
            return await _context.Fairs.ToListAsync();
        }

        // GET: api/Fairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fair>> GetFair(int id)
        {
          if (_context.Fairs == null)
          {
              return NotFound();
          }
            var fair = await _context.Fairs.FindAsync(id);

            if (fair == null)
            {
                return NotFound();
            }

            return fair;
        }

        // PUT: api/Fairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFair(int id, Fair fair)
        {
            if (id != fair.Id)
            {
                return BadRequest();
            }

            _context.Entry(fair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FairExists(id))
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

        // POST: api/Fairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fair>> PostFair(Fair fair)
        {
          if (_context.Fairs == null)
          {
              return Problem("Entity set 'CyberYarmarokContext.Fairs'  is null.");
          }
            _context.Fairs.Add(fair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFair", new { id = fair.Id }, fair);
        }

        // DELETE: api/Fairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFair(int id)
        {
            if (_context.Fairs == null)
            {
                return NotFound();
            }
            var fair = await _context.Fairs.FindAsync(id);
            if (fair == null)
            {
                return NotFound();
            }

            _context.Fairs.Remove(fair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FairExists(int id)
        {
            return (_context.Fairs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

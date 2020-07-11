using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HasniAPI.Model;

namespace HasniAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvasController : ControllerBase
    {
        private readonly SSContext _context;

        public TvasController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Tvas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tva>>> GetTva()
        {
            return await _context.Tva.ToListAsync();
        }

        // GET: api/Tvas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tva>> GetTva(int id)
        {
            var tva = await _context.Tva.FindAsync(id);

            if (tva == null)
            {
                return NotFound();
            }

            return tva;
        }

        // PUT: api/Tvas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTva(int id, Tva tva)
        {
            if (id != tva.IdTva)
            {
                return BadRequest();
            }

            _context.Entry(tva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TvaExists(id))
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

        // POST: api/Tvas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tva>> PostTva(Tva tva)
        {
            _context.Tva.Add(tva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTva", new { id = tva.IdTva }, tva);
        }

        // DELETE: api/Tvas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tva>> DeleteTva(int id)
        {
            var tva = await _context.Tva.FindAsync(id);
            if (tva == null)
            {
                return NotFound();
            }

            _context.Tva.Remove(tva);
            await _context.SaveChangesAsync();

            return tva;
        }

        private bool TvaExists(int id)
        {
            return _context.Tva.Any(e => e.IdTva == id);
        }
    }
}

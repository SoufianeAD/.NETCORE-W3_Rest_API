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
    public class MagasinsController : ControllerBase
    {
        private readonly SSContext _context;

        public MagasinsController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Magasins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magasin>>> GetMagasin()
        {
            return await _context.Magasin.ToListAsync();
        }

        // GET: api/Magasins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magasin>> GetMagasin(int id)
        {
            var magasin = await _context.Magasin.FindAsync(id);

            if (magasin == null)
            {
                return NotFound();
            }

            return magasin;
        }

        // PUT: api/Magasins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagasin(int id, Magasin magasin)
        {
            if (id != magasin.IdMagasin)
            {
                return BadRequest();
            }

            _context.Entry(magasin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagasinExists(id))
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

        // POST: api/Magasins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Magasin>> PostMagasin(Magasin magasin)
        {
            _context.Magasin.Add(magasin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagasin", new { id = magasin.IdMagasin }, magasin);
        }

        // DELETE: api/Magasins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Magasin>> DeleteMagasin(int id)
        {
            var magasin = await _context.Magasin.FindAsync(id);
            if (magasin == null)
            {
                return NotFound();
            }

            _context.Magasin.Remove(magasin);
            await _context.SaveChangesAsync();

            return magasin;
        }

        private bool MagasinExists(int id)
        {
            return _context.Magasin.Any(e => e.IdMagasin == id);
        }
    }
}

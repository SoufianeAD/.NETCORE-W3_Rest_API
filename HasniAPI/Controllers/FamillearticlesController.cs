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
    public class FamillearticlesController : ControllerBase
    {
        private readonly SSContext _context;

        public FamillearticlesController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Famillearticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Famillearticle>>> GetFamillearticle()
        {
            return await _context.Famillearticle.ToListAsync();
        }

        // GET: api/Famillearticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Famillearticle>> GetFamillearticle(int id)
        {
            var famillearticle = await _context.Famillearticle.FindAsync(id);

            if (famillearticle == null)
            {
                return NotFound();
            }

            return famillearticle;
        }

        // PUT: api/Famillearticles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamillearticle(int id, Famillearticle famillearticle)
        {
            if (id != famillearticle.IdFamilleArticle)
            {
                return BadRequest();
            }

            _context.Entry(famillearticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamillearticleExists(id))
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

        // POST: api/Famillearticles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Famillearticle>> PostFamillearticle(Famillearticle famillearticle)
        {
            _context.Famillearticle.Add(famillearticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamillearticle", new { id = famillearticle.IdFamilleArticle }, famillearticle);
        }

        // DELETE: api/Famillearticles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Famillearticle>> DeleteFamillearticle(int id)
        {
            var famillearticle = await _context.Famillearticle.FindAsync(id);
            if (famillearticle == null)
            {
                return NotFound();
            }

            _context.Famillearticle.Remove(famillearticle);
            await _context.SaveChangesAsync();

            return famillearticle;
        }

        private bool FamillearticleExists(int id)
        {
            return _context.Famillearticle.Any(e => e.IdFamilleArticle == id);
        }
    }
}

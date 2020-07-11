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
    public class SousfamillearticlesController : ControllerBase
    {
        private readonly SSContext _context;

        public SousfamillearticlesController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Sousfamillearticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sousfamillearticle>>> GetSousfamillearticle()
        {
            return await _context.Sousfamillearticle.ToListAsync();
        }

        // GET: api/Sousfamillearticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sousfamillearticle>> GetSousfamillearticle(int id)
        {
            var sousfamillearticle = await _context.Sousfamillearticle.FindAsync(id);

            if (sousfamillearticle == null)
            {
                return NotFound();
            }

            return sousfamillearticle;
        }

        // PUT: api/Sousfamillearticles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSousfamillearticle(int id, Sousfamillearticle sousfamillearticle)
        {
            if (id != sousfamillearticle.IdSousFamille)
            {
                return BadRequest();
            }

            _context.Entry(sousfamillearticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SousfamillearticleExists(id))
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

        // POST: api/Sousfamillearticles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sousfamillearticle>> PostSousfamillearticle(Sousfamillearticle sousfamillearticle)
        {
            _context.Sousfamillearticle.Add(sousfamillearticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSousfamillearticle", new { id = sousfamillearticle.IdSousFamille }, sousfamillearticle);
        }

        // DELETE: api/Sousfamillearticles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sousfamillearticle>> DeleteSousfamillearticle(int id)
        {
            var sousfamillearticle = await _context.Sousfamillearticle.FindAsync(id);
            if (sousfamillearticle == null)
            {
                return NotFound();
            }

            _context.Sousfamillearticle.Remove(sousfamillearticle);
            await _context.SaveChangesAsync();

            return sousfamillearticle;
        }

        private bool SousfamillearticleExists(int id)
        {
            return _context.Sousfamillearticle.Any(e => e.IdSousFamille == id);
        }
    }
}

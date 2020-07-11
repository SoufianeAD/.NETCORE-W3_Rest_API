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
    public class CommandesController : ControllerBase
    {
        private readonly SSContext _context;

        public CommandesController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
            return await _context.Commande.ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _context.Commande.FindAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.IdCommande)
            {
                return BadRequest();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commandes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommande", new { id = commande.IdCommande }, commande);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commande>> DeleteCommande(int id)
        {
            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commande.Remove(commande);
            await _context.SaveChangesAsync();

            return commande;
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.IdCommande == id);
        }
    }
}

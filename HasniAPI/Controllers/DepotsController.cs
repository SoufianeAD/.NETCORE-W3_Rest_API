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
    public class DepotsController : ControllerBase
    {
        private readonly SSContext _context;

        public DepotsController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Depots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetDepot()
        {
            return await _context.Depot.ToListAsync();
        }

        // GET: api/Depots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetDepot(int id)
        {
            var depot = await _context.Depot.FindAsync(id);

            if (depot == null)
            {
                return NotFound();
            }

            return depot;
        }

        // PUT: api/Depots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepot(int id, Depot depot)
        {
            if (id != depot.IdDepot)
            {
                return BadRequest();
            }

            _context.Entry(depot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepotExists(id))
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

        // POST: api/Depots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Depot>> PostDepot(Depot depot)
        {
            _context.Depot.Add(depot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepot", new { id = depot.IdDepot }, depot);
        }

        // DELETE: api/Depots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Depot>> DeleteDepot(int id)
        {
            var depot = await _context.Depot.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }

            _context.Depot.Remove(depot);
            await _context.SaveChangesAsync();

            return depot;
        }

        private bool DepotExists(int id)
        {
            return _context.Depot.Any(e => e.IdDepot == id);
        }
    }
}

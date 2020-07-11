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
    public class FamilleclientsController : ControllerBase
    {
        private readonly SSContext _context;

        public FamilleclientsController(SSContext context)
        {
            _context = context;
        }

        // GET: api/Familleclients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Familleclient>>> GetFamilleclient()
        {
            return await _context.Familleclient.ToListAsync();
        }

        // GET: api/Familleclients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Familleclient>> GetFamilleclient(int id)
        {
            var familleclient = await _context.Familleclient.FindAsync(id);

            if (familleclient == null)
            {
                return NotFound();
            }

            return familleclient;
        }

        // PUT: api/Familleclients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilleclient(int id, Familleclient familleclient)
        {
            if (id != familleclient.IdFamilleClient)
            {
                return BadRequest();
            }

            _context.Entry(familleclient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilleclientExists(id))
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

        // POST: api/Familleclients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Familleclient>> PostFamilleclient(Familleclient familleclient)
        {
            _context.Familleclient.Add(familleclient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilleclient", new { id = familleclient.IdFamilleClient }, familleclient);
        }

        // DELETE: api/Familleclients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Familleclient>> DeleteFamilleclient(int id)
        {
            var familleclient = await _context.Familleclient.FindAsync(id);
            if (familleclient == null)
            {
                return NotFound();
            }

            _context.Familleclient.Remove(familleclient);
            await _context.SaveChangesAsync();

            return familleclient;
        }

        private bool FamilleclientExists(int id)
        {
            return _context.Familleclient.Any(e => e.IdFamilleClient == id);
        }
    }
}

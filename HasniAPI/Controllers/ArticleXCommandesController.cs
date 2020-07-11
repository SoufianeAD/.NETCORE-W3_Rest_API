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
    public class ArticleXCommandesController : ControllerBase
    {
        private readonly SSContext _context;

        public ArticleXCommandesController(SSContext context)
        {
            _context = context;
        }

        // GET: api/ArticleXCommandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleXCommande>>> GetArticleXCommande()
        {
            return await _context.ArticleXCommande.ToListAsync();
        }

        // GET: api/ArticleXCommandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleXCommande>> GetArticleXCommande(int id)
        {
            var articleXCommande = await _context.ArticleXCommande.FindAsync(id);

            if (articleXCommande == null)
            {
                return NotFound();
            }

            return articleXCommande;
        }

        // PUT: api/ArticleXCommandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleXCommande(int id, ArticleXCommande articleXCommande)
        {
            if (id != articleXCommande.Id)
            {
                return BadRequest();
            }

            _context.Entry(articleXCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleXCommandeExists(id))
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

        // POST: api/ArticleXCommandes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArticleXCommande>> PostArticleXCommande(ArticleXCommande articleXCommande)
        {
            _context.ArticleXCommande.Add(articleXCommande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleXCommande", new { id = articleXCommande.Id }, articleXCommande);
        }

        // DELETE: api/ArticleXCommandes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticleXCommande>> DeleteArticleXCommande(int id)
        {
            var articleXCommande = await _context.ArticleXCommande.FindAsync(id);
            if (articleXCommande == null)
            {
                return NotFound();
            }

            _context.ArticleXCommande.Remove(articleXCommande);
            await _context.SaveChangesAsync();

            return articleXCommande;
        }

        private bool ArticleXCommandeExists(int id)
        {
            return _context.ArticleXCommande.Any(e => e.Id == id);
        }
    }
}

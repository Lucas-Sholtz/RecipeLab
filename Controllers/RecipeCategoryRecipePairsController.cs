using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeLab.Models;

namespace RecipeLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeCategoryRecipePairsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeCategoryRecipePairsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/RecipeCategoryRecipePairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeCategoryRecipePair>>> GetRecipeCategoryRecipePairs()
        {
            return await _context.RecipeCategoryRecipePairs.ToListAsync();
        }

        // GET: api/RecipeCategoryRecipePairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeCategoryRecipePair>> GetRecipeCategoryRecipePair(int id)
        {
            var recipeCategoryRecipePair = await _context.RecipeCategoryRecipePairs.FindAsync(id);

            if (recipeCategoryRecipePair == null)
            {
                return NotFound();
            }

            return recipeCategoryRecipePair;
        }

        // PUT: api/RecipeCategoryRecipePairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeCategoryRecipePair(int id, RecipeCategoryRecipePair recipeCategoryRecipePair)
        {
            if (id != recipeCategoryRecipePair.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeCategoryRecipePair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeCategoryRecipePairExists(id))
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

        // POST: api/RecipeCategoryRecipePairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeCategoryRecipePair>> PostRecipeCategoryRecipePair(RecipeCategoryRecipePair recipeCategoryRecipePair)
        {
            _context.RecipeCategoryRecipePairs.Add(recipeCategoryRecipePair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeCategoryRecipePair", new { id = recipeCategoryRecipePair.Id }, recipeCategoryRecipePair);
        }

        // DELETE: api/RecipeCategoryRecipePairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategoryRecipePair(int id)
        {
            var recipeCategoryRecipePair = await _context.RecipeCategoryRecipePairs.FindAsync(id);
            if (recipeCategoryRecipePair == null)
            {
                return NotFound();
            }

            _context.RecipeCategoryRecipePairs.Remove(recipeCategoryRecipePair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeCategoryRecipePairExists(int id)
        {
            return _context.RecipeCategoryRecipePairs.Any(e => e.Id == id);
        }
    }
}

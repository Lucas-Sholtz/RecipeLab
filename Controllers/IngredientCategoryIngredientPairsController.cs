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
    public class IngredientCategoryIngredientPairsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientCategoryIngredientPairsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/IngredientCategoryIngredientPairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientCategoryIngredientPair>>> GetIngredientCategoryIngredientPairs()
        {
            return await _context.IngredientCategoryIngredientPairs.ToListAsync();
        }

        // GET: api/IngredientCategoryIngredientPairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientCategoryIngredientPair>> GetIngredientCategoryIngredientPair(int id)
        {
            var ingredientCategoryIngredientPair = await _context.IngredientCategoryIngredientPairs.FindAsync(id);

            if (ingredientCategoryIngredientPair == null)
            {
                return NotFound();
            }

            return ingredientCategoryIngredientPair;
        }

        // PUT: api/IngredientCategoryIngredientPairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientCategoryIngredientPair(int id, IngredientCategoryIngredientPair ingredientCategoryIngredientPair)
        {
            if (id != ingredientCategoryIngredientPair.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientCategoryIngredientPair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientCategoryIngredientPairExists(id))
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

        // POST: api/IngredientCategoryIngredientPairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientCategoryIngredientPair>> PostIngredientCategoryIngredientPair(IngredientCategoryIngredientPair ingredientCategoryIngredientPair)
        {
            _context.IngredientCategoryIngredientPairs.Add(ingredientCategoryIngredientPair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientCategoryIngredientPair", new { id = ingredientCategoryIngredientPair.Id }, ingredientCategoryIngredientPair);
        }

        // DELETE: api/IngredientCategoryIngredientPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientCategoryIngredientPair(int id)
        {
            var ingredientCategoryIngredientPair = await _context.IngredientCategoryIngredientPairs.FindAsync(id);
            if (ingredientCategoryIngredientPair == null)
            {
                return NotFound();
            }

            _context.IngredientCategoryIngredientPairs.Remove(ingredientCategoryIngredientPair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientCategoryIngredientPairExists(int id)
        {
            return _context.IngredientCategoryIngredientPairs.Any(e => e.Id == id);
        }
    }
}

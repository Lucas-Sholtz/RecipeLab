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
    public class RecipeIngredientPairsController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeIngredientPairsController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/RecipeIngredientPairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeIngredientPair>>> GetRecipeIngredientPairs()
        {
            return await _context.RecipeIngredientPairs.ToListAsync();
        }

        // GET: api/RecipeIngredientPairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeIngredientPair>> GetRecipeIngredientPair(int id)
        {
            var recipeIngredientPair = await _context.RecipeIngredientPairs.FindAsync(id);

            if (recipeIngredientPair == null)
            {
                return NotFound();
            }

            return recipeIngredientPair;
        }

        // PUT: api/RecipeIngredientPairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeIngredientPair(int id, RecipeIngredientPair recipeIngredientPair)
        {
            if (id != recipeIngredientPair.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeIngredientPair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientPairExists(id))
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

        // POST: api/RecipeIngredientPairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeIngredientPair>> PostRecipeIngredientPair(RecipeIngredientPair recipeIngredientPair)
        {
            _context.RecipeIngredientPairs.Add(recipeIngredientPair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeIngredientPair", new { id = recipeIngredientPair.Id }, recipeIngredientPair);
        }

        // DELETE: api/RecipeIngredientPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeIngredientPair(int id)
        {
            var recipeIngredientPair = await _context.RecipeIngredientPairs.FindAsync(id);
            if (recipeIngredientPair == null)
            {
                return NotFound();
            }

            _context.RecipeIngredientPairs.Remove(recipeIngredientPair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeIngredientPairExists(int id)
        {
            return _context.RecipeIngredientPairs.Any(e => e.Id == id);
        }
    }
}

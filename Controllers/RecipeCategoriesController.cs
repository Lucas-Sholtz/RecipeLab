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
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public RecipeCategoriesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/RecipeCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeCategory>>> GetRecipeCategories()
        {
            return await _context.RecipeCategories.ToListAsync();
        }

        // GET: api/RecipeCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeCategory>> GetRecipeCategory(int id)
        {
            var recipeCategory = await _context.RecipeCategories.FindAsync(id);

            if (recipeCategory == null)
            {
                return NotFound();
            }

            return recipeCategory;
        }

        // PUT: api/RecipeCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeCategory(int id, RecipeCategory recipeCategory)
        {
            if (id != recipeCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeCategoryExists(id))
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

        // POST: api/RecipeCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeCategory>> PostRecipeCategory(RecipeCategory recipeCategory)
        {
            _context.RecipeCategories.Add(recipeCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeCategory", new { id = recipeCategory.Id }, recipeCategory);
        }

        // DELETE: api/RecipeCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            var recipeCategory = await _context.RecipeCategories.FindAsync(id);
            if (recipeCategory == null)
            {
                return NotFound();
            }

            _context.RecipeCategories.Remove(recipeCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeCategoryExists(int id)
        {
            return _context.RecipeCategories.Any(e => e.Id == id);
        }
    }
}

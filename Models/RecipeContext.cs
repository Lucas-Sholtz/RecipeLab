using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeLab.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
        public virtual DbSet<IngredientCategoryIngredientPair> IngredientCategoryIngredientPairs { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
        public virtual DbSet<RecipeCategoryRecipePair> RecipeCategoryRecipePairs { get; set; }
        public virtual DbSet<RecipeIngredientPair> RecipeIngredientPairs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeCategoryRecipePairs = new List<RecipeCategoryRecipePair>();
            RecipeIngredientPairs = new List<RecipeIngredientPair>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Назва рецепта")]
        public string Name { get; set; }

        [Display(Name = "Опис рецепта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер автора")]
        public int AuthorId { get; set; }

        public virtual ICollection<RecipeCategoryRecipePair> RecipeCategoryRecipePairs { get; set; }
        public virtual ICollection<RecipeIngredientPair> RecipeIngredientPairs { get; set; }
        public virtual Author Author { get; set; }
    }
}

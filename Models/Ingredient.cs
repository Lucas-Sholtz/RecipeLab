using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredientPairs = new List<RecipeIngredientPair>();
            IngredientCategoryIngredientPairs = new List<IngredientCategoryIngredientPair>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Назва інгридієнта")]
        public string Name { get; set; }

        [Display(Name = "Зображення блюда")]
        public byte[] Image { get; set; }

        public virtual ICollection<RecipeIngredientPair> RecipeIngredientPairs { get; set; }
        public virtual ICollection<IngredientCategoryIngredientPair> IngredientCategoryIngredientPairs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class IngredientCategory
    {
        public IngredientCategory()
        {
            IngredientCategoryIngredientPairs = new List<IngredientCategoryIngredientPair>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Ім'я категорії")]
        public string Name { get; set; }

        [Display(Name = "Опис категорії")]
        public string Description { get; set; }

        public virtual ICollection<IngredientCategoryIngredientPair> IngredientCategoryIngredientPairs { get; set; }
    }
}

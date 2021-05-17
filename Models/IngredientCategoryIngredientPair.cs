using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class IngredientCategoryIngredientPair
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер інгридієнта")]
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер категорії")]
        public int IngredientCategoryId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual IngredientCategory IngredientCategory { get; set; }
    }
}

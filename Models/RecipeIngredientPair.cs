using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class RecipeIngredientPair
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер кроку")]
        public int Step { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Кількість")]
        public decimal Ammount { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер рецепта")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер інгридієнта")]
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}

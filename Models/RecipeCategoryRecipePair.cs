using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class RecipeCategoryRecipePair
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер рецепта")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Обов'язкове поле")]
        [Display(Name = "Номер категорії")]
        public int RecipeCategoryId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual RecipeCategory RecipeCategory { get; set; }
    }
}

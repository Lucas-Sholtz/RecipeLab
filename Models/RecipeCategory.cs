using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeLab.Models
{
    public class RecipeCategory
    {
        public RecipeCategory()
        {
            RecipeCategoryRecipePairs = new List<RecipeCategoryRecipePair>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва категорії")]
        [Display(Name = "Ім'я категорії")]
        public string Name { get; set; }

        [Display(Name = "Опис категорії")]
        public string Description { get; set; }

        public virtual ICollection<RecipeCategoryRecipePair> RecipeCategoryRecipePairs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class RecipeList
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUsers ApplicationUser { get; set; }

        public int ResipesId { get; set; }

        [NotMapped]
        [ForeignKey("ResipesId")]
        public virtual Recipes Recipes { get; set; }

        
        public IEnumerable<Category> category { get; set; }

        public IngredientCollection ingredientCollection { get; set; }

        public IEnumerable<IngredientCollection> ingredientCollections { get; set; }

        public IEnumerable<Ingredient> Ingredient { get; set; }

        public IEnumerable<MeasurmentUnit> MeasurmentUnit { get; set; }


    }
}

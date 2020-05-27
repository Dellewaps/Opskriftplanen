using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models.ViewModels
{
    public class RecipeListViewModel
    {
        public RecipeList RecipeList { get; set; }
        public Recipes Recipes { get; set; }

        public IEnumerable<Category> category { get; set; }

        public IngredientCollection ingredientCollection { get; set; }

        public IEnumerable<IngredientCollection> ingredientCollections { get; set; }

        public IEnumerable<Ingredient> Ingredient { get; set; }

        public IEnumerable<MeasurmentUnit> MeasurmentUnit { get; set; }

        public int ResipesId { get; set; }

        
    }
}

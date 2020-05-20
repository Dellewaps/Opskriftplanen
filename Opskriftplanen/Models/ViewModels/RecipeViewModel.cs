using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models.ViewModels
{
    public class RecipeViewModel
    {
        public Recipes Recipes { get; set; }

        public IEnumerable<Category> category { get; set; }

        public IngredientCollection ingredientCollection { get; set; }

        //public int IngrdientId { get; set; }
        public IEnumerable<Ingredient> Ingredient { get; set; }

        //public int MeasurmentUnitId { get; set; }
        public IEnumerable<MeasurmentUnit> MeasurmentUnit { get; set; }
    }
}

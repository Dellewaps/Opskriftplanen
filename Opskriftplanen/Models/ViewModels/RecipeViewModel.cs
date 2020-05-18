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

        public IEnumerable<Measurment> measurment { get; set; }
    }
}

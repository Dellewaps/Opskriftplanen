using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string IngredientName { get; set; }

        public virtual ICollection<IngredientCollection> IngredientCollection { get; set; }
    }
}

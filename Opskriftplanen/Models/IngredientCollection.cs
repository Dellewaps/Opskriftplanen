using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class IngredientCollection
    {
        public int Id { get; set; }

        [ForeignKey("RecipesId")]
        public int RecipesId { get; set; }

        public Recipes Recipes { get; set; }

        [ForeignKey("MeasurmentId")]
        public int MeasurmentId { get; set; }

        public Measurment Measurment { get; set; }

        [ForeignKey("IngredientId")]
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        [ForeignKey("MeasurmentUnitId")]
        public int MeasurmentUnitId { get; set; }

        public MeasurmentUnit MeasurmentUnit { get; set; }

    }
}

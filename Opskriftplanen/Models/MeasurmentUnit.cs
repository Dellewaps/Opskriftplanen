using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class MeasurmentUnit
    {
        public int Id { get; set; }

        public string MeasurUnit { get; set; }

        public virtual ICollection<IngredientCollection> IngredientCollection { get; set; }
    }
}

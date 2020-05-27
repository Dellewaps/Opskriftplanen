using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class Measurment
    {
        public int Id { get; set; }

        public int Measures { get; set; }

        public virtual ICollection<IngredientCollection> IngredientCollection { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class WeekDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        [ForeignKey("PlanId")]
        public virtual PlanHeader PlanHeader { get; set; }

        [Required]
        public int RecipesId { get; set; }

        [ForeignKey("RecipesId")]
        public virtual Recipes Recipes { get; set; }

        public string Name { get; set; }

        public virtual IngredientCollection IngredientCollection { get; set; }

        public int WeekPlanId { get; set; }

        public virtual WeekPlan WeekPlan { get; set; }
    }
}

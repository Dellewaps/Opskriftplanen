using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models.ViewModels
{
    public class PlanDetailsList
    {
        public List<RecipeList> RecipeList { get; set; }

        public PlanHeader PlanHeader { get; set; }

        public WeekPlan WeekPlan { get; set; }

        public IEnumerable<Recipes> Recipe { get; set; }

    }
}

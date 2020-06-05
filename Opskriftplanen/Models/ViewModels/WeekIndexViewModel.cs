using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models.ViewModels
{
    public class WeekIndexViewModel
    {
        public Recipes Recipes { get; set; }

        public WeekPlan WeekPlan { get; set; }

        public IEnumerable<WeekPlan> EnumWeekPlan { get; set; }

        public IEnumerable<Recipes> EnumRecipes { get; set; }

        public WeekDetails WeekDetails { get; set; }

        public PlanHeader PlanHeader { get; set; }
    }
}

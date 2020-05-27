using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Recipes> Recipes { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}

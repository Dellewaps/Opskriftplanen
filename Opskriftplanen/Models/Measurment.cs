using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class Measurment
    {
        public int Id { get; set; }

        public string Ingredient { get; set; }

        public string MeasurmentName { get; set; }

        public int Measures { get; set; }

        public List<Measurment> Measurments { get; set; }
    }
}

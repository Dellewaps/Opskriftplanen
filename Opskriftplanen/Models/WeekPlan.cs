using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class WeekPlan
    {
        [Key]
        public int Id { get; set; }

        public string Week { get; set; }

        public int Monday { get; set; }

        public int Tuesday { get; set; }

        public int Wednesday { get; set; }

        public int Thursday { get; set; }

        public int Friday { get; set; }

        public int Saturday { get; set; }

        public int Sunday { get; set; }        

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUsers ApplicationUser { get; set; }
    }
}

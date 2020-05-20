using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class Recipes
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int PersonCount { get; set; }

        public string Image { get; set; }

        [ForeignKey("IngredientCollectionsId")]
        public int IngredientCollectionsId { get; set; }

        public virtual ICollection<IngredientCollection> IngredientCollection { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        

    }
}

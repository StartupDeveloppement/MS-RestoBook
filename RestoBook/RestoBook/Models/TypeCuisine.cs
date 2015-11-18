using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class TypeCuisine
    {
        public TypeCuisine()
        {
            this.Restaurants = new HashSet<Restaurants>();
        }

        [Key]
        public int Id_Cuisine { get; set; }

        [Required(ErrorMessage ="Le type de cuisine est requis")]
        [Display(Name ="Type de cuisine")]
        public string lb_cuisne{get;set;}

        public virtual ICollection<Restaurants> Restaurants { get; set; }
    }
}

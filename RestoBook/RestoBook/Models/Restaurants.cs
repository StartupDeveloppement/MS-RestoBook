using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class Restaurants
    {
        public Restaurants()
        {
            //this.Villes = new HashSet<Ville>();
            this.TypeCuisines = new HashSet<TypeCuisine>();
            this.Adresses = new HashSet<Adresse>();
        }

        [Key]
        public int Id_Restaurant { get; set; }

        [Required(ErrorMessage ="Le nom du restaurant est requis")]
        [Display(Name = "Nom")]
        public string lb_nom { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Site web")]
        public string lb_web { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Téléphone")]
        public string lb_tel { get; set; }

        public bool isActive { get; set; }

        //public virtual ICollection<Ville> Villes { get; set; }
        public virtual ICollection<TypeCuisine> TypeCuisines { get; set; }
        public virtual ICollection<Adresse> Adresses { get; set; }

    }
}

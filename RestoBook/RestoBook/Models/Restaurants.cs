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
            this.TypeCuisines = new HashSet<TypeCuisine>();
            this.Adresses = new HashSet<Adresse>();
            this.Notations = new HashSet<Notation>();
            this.Pictures = new HashSet<Picture>();
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

        public string lb_description { get; set; }

        public bool isActive { get; set; }

        public virtual ICollection<TypeCuisine> TypeCuisines { get; set; }
        public virtual ICollection<Adresse> Adresses { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

    }
}

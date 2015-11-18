using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class Adresse
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la rue est requis")]
        [Display(Name = "Rue")]
        public string lb_rue { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Le code postal est requis")]
        [Display(Name = "Code Postal")]
        public string lb_codepostal { get; set; }

        public int VilleId { get; set; }

        public virtual Ville Villes { get; set; }
        public int RestaurantsId { get; set; }
        public virtual Restaurants Restaurants { get; set; }
    }
}

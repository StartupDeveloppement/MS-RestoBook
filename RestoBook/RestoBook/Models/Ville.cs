using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class Ville
    {
        public Ville()
        {
            this.Adresses = new HashSet<Adresse>();
        }
        [Key]
        public int Id_Ville { get; set; }

        [Required(ErrorMessage ="Le nom de ville est requis")]
        [Display(Name="Ville")]
        public string lb_ville { get; set; }
        public virtual ICollection<Adresse> Adresses { get; set; }

    }
}

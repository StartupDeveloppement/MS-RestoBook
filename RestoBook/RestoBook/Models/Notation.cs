using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class Notation
    {
        public Notation()
        {
            this.Restaurants = new HashSet<Restaurants>();
        }

        public int Id { get; set; }

        [Required]
        public int Note { get; set; }

        [NotMapped]
        public string nameId{ get; set; }
        [NotMapped]
        public string nameClass { get; set; }

        public ICollection<Restaurants> Restaurants { get; set; }
    }
}

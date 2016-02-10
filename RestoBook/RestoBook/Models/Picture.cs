using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class Picture
    {
        [Key]
        public int Id_Picture { get; set; }
        public string lb_Name { get; set; }

        public byte[] lb_Picure { get; set; }
        public bool banner { get; set; }

        public int fk_Restaurant { get; set; }

        public virtual Restaurants Restaurants { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Anonymous_Class
{
    class InfoRestaurant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Rue { get; set; }
        public string Cp { get; set; }
        public bool? Active { get; set; }
    }
}

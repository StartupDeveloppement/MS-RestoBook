using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models.ViewModels
{
    public class ViewModelListerRestaurants
    {
        public int Id { get; set; }
        public int IdCuisine { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string StrCuisine { get; set; }
        public double Notation { get; set; }
 
    }
}

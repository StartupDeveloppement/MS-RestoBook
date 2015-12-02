using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models.ViewModels
{
    public class ViewModelGroupRestaurants
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public double Notation { get; set; }
        public List<string> ListCuisine { get; set; }
        public Dictionary<int,string> DictCuisine { get; set; }
    }
}

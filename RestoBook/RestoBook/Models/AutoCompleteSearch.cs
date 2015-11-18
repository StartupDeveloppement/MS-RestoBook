using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class AutoCompleteSearchRestaurant
    {
        public string Nom { get; set; }
        public string Adresse { get; set; }

    }

    //public class AutoCompleteSearchGroup
    //{
    //    public int Key { get; set; }
    //    public IEnumerable<string> Rue { get; set; }
    //    public IEnumerable<AutoCompleteSearch> AutoCompleteSearch { get; set; }
    //}

    public class AutoCompleteSearchVille
    {
        public string Ville { get; set; }

    }

    public class AutoCompleteSearchVilledfd
    {
        public List<AutoCompleteSearchRestaurant> Villea { get; set; }
        public List<AutoCompleteSearchVille> Ville { get; set; }

    }
}

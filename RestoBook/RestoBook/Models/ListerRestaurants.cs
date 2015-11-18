using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class ListerRestaurants
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string StrCuisine { get; set; }
        public List<string> ListCuisine { get; set; }

        public ListerRestaurants(int iD,string Nom,string Ville,string Rue,string CodePostal,List<string> ListCuisine)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Ville = Ville;
            this.Rue = Rue;
            this.CodePostal = CodePostal;
            this.ListCuisine = ListCuisine;
        }

        public ListerRestaurants() { }
    }
}

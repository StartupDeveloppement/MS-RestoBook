using RestoBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RestoBook.Models
{
    public class ViewModelRestaurant
    {
        public Ville m_ville { get; set; }
        public TypeCuisine m_typecuisne { get; set; }
        public Restaurants m_restaurant { get; set; }
        public Adresse m_adresse { get; set; }

        [Required(ErrorMessage ="Le type de cuisine est requis")]
        public string[] SelectedItemsCuisine { get; set; }
        public IEnumerable<TypeCuisine> ItemsCuisine {get;set;}
        
    }
}

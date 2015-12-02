using RestoBook.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestoBook.Models.ViewModels
{
    public class ViewModelAddRestaurant
    {
        public Ville m_ville { get; set; }
        public TypeCuisine m_typecuisne { get; set; }
        public Restaurants m_restaurant { get; set; }
        public Adresse m_adresse { get; set; }
        public Notation m_notation { get; set; }

        [Required(ErrorMessage = "Le type de cuisine est requis")]
        public string[] SelectedItemsCuisine { get; set; }
        public IEnumerable<TypeCuisine> ItemsCuisine { get; set; }


    }
}

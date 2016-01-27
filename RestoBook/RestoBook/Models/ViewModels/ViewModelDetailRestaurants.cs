using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models.ViewModels
{
    public class ViewModelDetailRestaurants
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string CP { get; set; }
        public string Ville { get; set; }
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:0.0}", ApplyFormatInEditMode = true)]
        public double Notation { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public List<string> Cuisine { get; set; }


    }
}

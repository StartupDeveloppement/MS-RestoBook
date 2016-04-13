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
        public string CuisineA { get; set; }
        public List<string> Cuisine { get; set; }
        public List<byte[]> BytePicture { get; set; }
        public List<string> NamePicture { get; set; }
        public List<string> Roles { get; set; }

        public Dictionary<string,string> Test { get; set; }
    }
}

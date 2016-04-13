
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoBook.ViewModel
{
    class DetailsViewModel:MainViewModel
    {
        private string str_nom;
        private string str_rue;
        private string str_ville;
        private string str_cuisine;
        private string str_cp;
        private string id;
        private bool active;

        public DetailsViewModel()
        {
        }

        public DetailsViewModel(RestoBookServiceReference.Restaurants restaurant)
        {
            this.id = restaurant.Id.ToString();
            this.str_nom = restaurant.Nom;
            this.str_rue = restaurant.Rue;
            this.str_ville = restaurant.Ville;
            this.str_cp = restaurant.CP;
            this.str_cuisine= restaurant.Cuisine;
            this.active = restaurant.Active;
        }

        public string DetailsNom
        {
            get
            { return this.str_nom; }
            set
            {
                this.str_nom = value;
                onPropertyChanged("DetailsNom");
            }
        }

        public string DetailsID
        {
            get
            { return this.id; }
            set
            {
                this.id = value;
                onPropertyChanged("DetailsID");
            }

        }
        public string DetailsRue
        {
            get
            { return this.str_rue; }
            set
            {
                this.str_rue = value;
                onPropertyChanged("DetailsRue");
            }
        }

        public string DetailsVille
        {
            get { return this.str_ville; }
            set
            {
                this.str_ville = value;
                onPropertyChanged("DetailsVille");
            }
        }
        public string DetailsCuisine
        {
            get { return this.str_cuisine; }
            set
            {
                this.str_cuisine = value;
                onPropertyChanged("DetailsCuisine");
            }
        }

        public string DetailsCP
        {
            get { return this.str_cp; }
            set
            {
                this.str_cp = value;
                onPropertyChanged("DetailsCP");
            }
        }

        public bool DetailsActive
        {
            get { return this.active; }
            set
            {
                this.active = value;
                onPropertyChanged("DetailsActive");
            }
        }
    }
}

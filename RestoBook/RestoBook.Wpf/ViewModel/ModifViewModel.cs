using RestoBook.Common.SysWindows;
using RestoBook.RestoBookServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RestoBook.ViewModel
{
    class DataGridImage
    {
        public BitmapSource Images { get; set; }
    }

    class ModifViewModel : MainViewModel
    {
        private ICommand commandBrowse;
        private string str_nom;
        private string str_ville;
        private string str_rue;
        private string str_cp;
        private string str_pathfolder;
        private string id;
        private bool active;
        private BitmapSource bitmapSource;
        private ObservableCollection<DataGridImage> lstImage = new ObservableCollection<DataGridImage>();

        public ModifViewModel() { }
        public ModifViewModel(Restaurants restaurant)
        {
            this.id = restaurant.Id.ToString();
            this.str_nom = restaurant.Nom;
            this.str_rue = restaurant.Rue;
            this.str_ville = restaurant.Ville;
            this.active = restaurant.Active;
            this.str_cp = restaurant.CP;
        }

        public ICommand BtnCommandBrowse
        {
            get
            {
                if (this.commandBrowse == null)
                {
                    this.commandBrowse = new RelayCommand(param => ImageBitmap());
                }
                return commandBrowse;
            }
            set
            {
                this.commandBrowse = value;
                onPropertyChanged("BtnCommandBrowse");
            }
        }

        public ObservableCollection<DataGridImage> DataGridImageRestaurant
        {
            get { return this.lstImage; }
        }

        public string ModifNom
        {
            get { return this.str_nom; }
            set
            {
                this.str_nom = value;
                onPropertyChanged("ModifNom");
            }
        }

        public bool ModifActive
        {
            get { return this.active; }
            set
            {
                this.active = value;
                onPropertyChanged("ModifActive");
            }
        }

        public string ModifVille
        {
            get { return this.str_ville; }
            set
            {
                this.str_ville = value;
                onPropertyChanged("ModifVille");
            }
        }

        public string ModifRue
        {
            get { return this.str_rue; }
            set
            {
                this.str_rue = value;
                onPropertyChanged("ModifRue");
            }
        }

        public string ModifCP
        {
            get { return this.str_cp; }
            set
            {
                this.str_cp = value;
                onPropertyChanged("ModifCP");
            }
        }

        public string PathFolder
        {
            get { return this.str_pathfolder; }
            set
            {
                this.str_pathfolder = value;
                onPropertyChanged("PathFolder");
            }
        }

        public string DetailsID
        {
            get { return this.id.ToString(); }
            set
            {
                this.id= value;
                onPropertyChanged("DetailsID");
            }
        }

        public BitmapSource h
        {
            get { return this.bitmapSource; }
            set
            {
                this.bitmapSource = value;
                onPropertyChanged("Image");
            }
        }

        public void ImageBitmap()
        {
            PathFolder = FolderBrowser.OpenFolderBrowser();
            foreach (var item in Directory.EnumerateFiles(str_pathfolder))
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(item, true);
                bitmapSource = BitmapConversion.BitmapToBitmapSource(bitmap);
                lstImage.Add(new DataGridImage() { Images = bitmapSource });
            }
        }
    }
}

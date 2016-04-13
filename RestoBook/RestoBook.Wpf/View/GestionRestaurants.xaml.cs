using RestoBook.Common.Pictures;
using RestoBook.Common.SysWindows;
using RestoBook.RestoBookServiceReference;
using RestoBook.ViewModel;
using System.IO;
using System.Windows;
using RestoBook.Common.Validation;
using RestoBook.Common.Anonymous_Class;
using RestoBook.BusinessModel;

namespace RestoBook.View
{
    /// <summary>
    /// Logique d'interaction pour GestionImages.xaml
    /// </summary>
    public partial class GestionRestaurant : Window
    {
        private ModifViewModel modifView;
        private Restaurants restaurant;

        public GestionRestaurant()
        {
            InitializeComponent();
        }

        public GestionRestaurant(Restaurants restaurant)
        {
            InitializeComponent();
            this.restaurant = restaurant;
            modifView = new ModifViewModel(restaurant);
            this.DataContext = modifView;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            //this.lbPathFolder.Content = FolderBrowser.OpenFolderBrowser();
        }

        private void btnValiderGestion_Click(object sender, RoutedEventArgs e)
        {
            var imageSelected = (object)this.PictureDataGrid.SelectedItem;
            ValidationForm.ValidationInput(this.txtBoxCP.Text.Trim(), "Code postal");
            ValidationForm.ValidationInput(this.txtBoxNom.Text.Trim(), "Nom");
            ValidationForm.ValidationInput(this.txtBoxRue.Text.Trim(), "Rue");

            InfoRestaurant lstInfoRestaurant = new InfoRestaurant()
            {
                Id = int.Parse(this.labelID.Content.ToString()),
                Nom = this.txtBoxNom.Text.Trim(),
                Cp = this.txtBoxCP.Text.Trim(),
                Rue = this.txtBoxRue.Text.Trim(),
                Active = this.checkBoxActive.IsChecked
            };

            byte[] byteImage = new byte[] { };
            string name = string.Empty;

            foreach (var file in Directory.EnumerateFiles(this.lbPathFolder.Content.ToString()))
            {
                name = Path.GetFileName(file);
                byteImage = ConvertPicture.ImageToByteArray(file);
            }

          

            UpdateModel.Update(lstInfoRestaurant, byteImage,name);
            
            //string path = this.lbPathFolder.Content.ToString();
            //foreach (var imagefilePath in Directory.EnumerateFiles(path))
            //{
            //    var imageByte = ConvertPicture.ImageToByteArray(imagefilePath);
            //    Insert.AddPicture(restaurant.Id, imageByte);
            //}
        }
    }
}

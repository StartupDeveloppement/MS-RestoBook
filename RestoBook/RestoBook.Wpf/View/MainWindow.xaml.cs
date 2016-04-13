using RestoBook.RestoBookServiceReference;
using RestoBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RestoBook.Common.SysWindows;

namespace RestoBook.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static MainWindow main;

        internal Boolean ActiveDetails
        {
            get { return tabDetails.IsActive; }
            set { Dispatcher.Invoke(new Action(() => { this.tabDetails.IsActive = value; })); }
        }
        internal Object DetailDtaContext
        {
            get { return GridDetails.DataContext; }
            set { Dispatcher.Invoke(new Action(() => { this.GridDetails.DataContext = value; })); }
        }

        public MainWindow()
        {
            InitializeComponent();
            main = this;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.labelID.Content.ToString());
            Restaurants restaurant = new Restaurants()
            {
                Id = id,
                Nom = this.txtBlockNom.Text,
                Cuisine = this.txtBlockCuisine.Text,
                Rue = this.txtBlockRue.Text,
                Ville = this.txtBlockVille.Text,
                CP = this.txtBlockCP.Text,
                Active = (bool)this.labelActive.Content
        };
            GestionRestaurant gestionrRestautant = new GestionRestaurant(restaurant);
            gestionrRestautant.ShowDialog();
        }
    }
}

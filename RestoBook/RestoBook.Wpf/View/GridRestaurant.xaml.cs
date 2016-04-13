using RestoBook.RestoBookServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestoBook.ViewModel;


namespace RestoBook.View
{
    /// <summary>
    /// Logique d'interaction pour GridRestaurant.xaml
    /// </summary>
    public partial class GridRestaurant : UserControl
    {
        public static DependencyProperty ListerRestaurantProperty =
            DependencyProperty.Register(
                "ListerRestaurant", 
                typeof(IEnumerable<Restaurants>), 
                typeof(GridRestaurant), 
                new PropertyMetadata(null));

        public GridRestaurant()
        {
            InitializeComponent();
        }

        public IEnumerable<Restaurants> ListerRestaurant
        {
            get
            {
                return (IEnumerable<Restaurants>)GetValue(ListerRestaurantProperty);
            }
            set
            {
                SetValue(ListerRestaurantProperty, value);
            }
        }

        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var restaurantSelected = (Restaurants)dataGrid.SelectedItem;
            MainWindow.main.ActiveDetails = true;
            DetailsViewModel detailView = new DetailsViewModel(restaurantSelected);
            MainWindow.main.DetailDtaContext = detailView;
        }
    }
}

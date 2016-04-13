using System.Collections.Generic;
using RestoBook.RestoBookServiceReference;

namespace RestoBook.ViewModel
{
    public class GridViewModel : MainViewModel
    {
        private RestoBookRestaurantServiceClient restoServiceClient = new RestoBookRestaurantServiceClient();
        private IEnumerable<Restaurants> lstListerRestaurantApprouve;
        private IEnumerable<Restaurants> lstListerRestaurantNonApprouve;

        public GridViewModel()
        {
            this.lstListerRestaurantApprouve = this.RefreshRestaurantByState(true);
            this.lstListerRestaurantNonApprouve = this.RefreshRestaurantByState(false);
        }

        public IEnumerable<Restaurants> ListerApprouver
        {
            get
            {
                return this.lstListerRestaurantApprouve;
            }
            set
            {
                this.lstListerRestaurantApprouve = value;
                onPropertyChanged("ListerApprouver");
                this.RefreshRestaurantByState(true);
            }
        }

        public IEnumerable<Restaurants> ListerNonApprouver
        {
            get
            {
                return this.lstListerRestaurantNonApprouve;
            }
            set
            {
                this.lstListerRestaurantNonApprouve = value;
                onPropertyChanged("ListerNonApprouver");
                this.RefreshRestaurantByState(false);
            }
        }

        public IEnumerable<Restaurants> RefreshRestaurantByState(bool state)
        {
            this.restoServiceClient.GetRestaurantByStateCompleted += (s, e) =>
            {
                this.lstListerRestaurantApprouve = e.Result;
                this.lstListerRestaurantNonApprouve = e.Result;
            };
            return this.restoServiceClient.GetRestaurantByState(state);
        }
        
    }
}

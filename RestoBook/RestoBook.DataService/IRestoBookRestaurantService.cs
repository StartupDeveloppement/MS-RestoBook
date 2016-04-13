using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestoBook.DataService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IRestoBookService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRestoBookRestaurantService
    {
        [OperationContract]
        IEnumerable<Restaurants> GetAllRestaurant();
        [OperationContract]
        IEnumerable<Restaurants> GetRestaurantByState(bool active);
    }

    [DataContract]
    public class Restaurants
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Cuisine { get; set; }
        [DataMember]
        public string Rue { get; set; }
        [DataMember]
        public string Ville { get; set; }
        [DataMember]
        public string CP { get; set; }
        [DataMember]
        public bool? Active { get; set; }
    }

}

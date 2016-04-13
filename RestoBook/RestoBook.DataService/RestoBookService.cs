using RestoBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestoBook.DataService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "RestoBookService" à la fois dans le code et le fichier de configuration.
    public class RestoBookService : IRestoBookRestaurantService
    {
        public IEnumerable<Restaurants> GetAllRestaurant()
        {
            using (var model = new RestoBookEntities())
            {
                var result = from restaurant in model.Restaurants
                             from cuisine in restaurant.TypeCuisine
                             join addr in model.Adresse on restaurant.Id_Restaurant equals addr.RestaurantsId
                             join ville in model.Ville on addr.VilleId equals ville.Id_Ville
                             select new
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom.Trim(),
                                 Active = restaurant.isActive,
                                 Rue = addr.lb_rue.Trim(),
                                 CP = addr.lb_codepostal.Trim(),
                                 Ville = ville.lb_ville.Trim(),
                                 Cuisine = cuisine.lb_cuisne.Trim()
                             };

                var gpResult = from gpRestaurant in result.AsEnumerable()
                               group gpRestaurant by gpRestaurant.Nom into gp
                               select new Restaurants()
                               {
                                   Id = gp.Select(s=>s.Id).FirstOrDefault(),
                                   Nom = gp.Select(s => s.Nom).FirstOrDefault(),
                                   Active = gp.Select(s => s.Active).FirstOrDefault(),
                                   Rue = gp.Select(s => s.Rue).FirstOrDefault(),
                                   CP = gp.Select(s => s.CP).FirstOrDefault(),
                                   Ville = gp.Select(s => s.Ville).FirstOrDefault(),
                                   Cuisine = String.Join(",", gp.Select(s => s.Cuisine))
                               };

                return gpResult.ToList();
            }
        }

        public IEnumerable<Restaurants> GetRestaurantByState(bool active)
        {
            using (var model = new RestoBookEntities())
            {
                var result = from restaurant in model.Restaurants
                             from cuisine in restaurant.TypeCuisine
                             join addr in model.Adresse on restaurant.Id_Restaurant equals addr.RestaurantsId
                             join ville in model.Ville on addr.VilleId equals ville.Id_Ville
                             where restaurant.isActive == active
                             select new
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom.Trim(),
                                 Active = restaurant.isActive,
                                 Rue = addr.lb_rue.Trim(),
                                 CP = addr.lb_codepostal.Trim(),
                                 Ville = ville.lb_ville.Trim(),
                                 Cuisine = cuisine.lb_cuisne.Trim()
                             };

                var gpResult = from gpRestaurant in result.AsEnumerable()
                               group gpRestaurant by gpRestaurant.Nom into gp
                               select new Restaurants()
                               {
                                   Id = gp.Select(s => s.Id).FirstOrDefault(),
                                   Nom = gp.Select(s => s.Nom).FirstOrDefault(),
                                   Active = gp.Select(s => s.Active).FirstOrDefault(),
                                   Rue = gp.Select(s => s.Rue).FirstOrDefault(),
                                   CP = gp.Select(s => s.CP).FirstOrDefault(),
                                   Ville = gp.Select(s => s.Ville).FirstOrDefault(),
                                   Cuisine = String.Join(",", gp.Select(s => s.Cuisine))
                               };

                return gpResult.ToList();
            }
        }
    }
}

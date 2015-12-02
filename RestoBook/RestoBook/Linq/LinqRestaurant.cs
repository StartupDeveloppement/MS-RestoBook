using RestoBook.DAL;
using RestoBook.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RestoBook.Linq
{
    public class LinqRestaurant
    {
        public int ExistRestaurant(string str_nom, string str_rue, string str_cp, string str_ville)
        {
            using (var db = new RestaurantDbContext())
            {
                var existingRestaurant = from restaurant in db.db_restaurants
                                         join addr in db.db_addresse on restaurant.Id_Restaurant equals addr.RestaurantsId
                                         join ville in db.db_ville on addr.VilleId equals ville.Id_Ville
                                         where restaurant.lb_nom.ToLower().Trim().Equals(str_nom.ToLower().Trim())
                                         && addr.lb_rue.ToLower().Trim().Equals(str_rue.ToLower().Trim())
                                         && addr.lb_codepostal.ToLower().Trim().Equals(str_cp.ToLower().Trim())
                                         && ville.lb_ville.ToLower().Trim().Equals(str_ville.ToLower().Trim())
                                         select restaurant;
                return existingRestaurant.Count();
            }
        }




        public  List<ViewModelSearch> Search(string search)
        {
            using (var db = new RestaurantDbContext())
            {
                var result = from restaurant in db.db_restaurants
                             join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                             join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                             where restaurant.isActive && (restaurant.lb_nom.ToLower().Trim().Contains(search.ToLower().Trim())
                             || addresse.lb_rue.ToLower().Trim().Equals(search.ToLower().Trim())
                             || addresse.lb_codepostal.ToLower().Trim().Equals(search.ToLower().Trim())
                             || ville.lb_ville.ToLower().Trim().Equals(search.ToLower().Trim()))
                             select new ViewModelSearch()
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom,
                                 Adresse = addresse.lb_rue + ", " + addresse.lb_codepostal + " " + ville.lb_ville,
                             };
                return result.ToList();
            }
        }


        public List<ViewModelListerRestaurants> ListerRestaurants(string search)
        {
            using (var db = new RestaurantDbContext())
            {
                var result = from restaurant in db.db_restaurants
                             from cuisine in restaurant.TypeCuisines
                             from note in restaurant.Notations
                             join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                             join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                             where restaurant.isActive && (restaurant.lb_nom.ToLower().Trim().Equals(search.ToLower().Trim())
                             || addresse.lb_rue.ToLower().Trim().Equals(search.ToLower().Trim())
                             || addresse.lb_codepostal.ToLower().Trim().Equals(search.ToLower().Trim())
                             || ville.lb_ville.ToLower().Trim().Equals(search.ToLower().Trim()))
                             select new ViewModelListerRestaurants()
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom,
                                 Ville = ville.lb_ville,
                                 StrCuisine = cuisine.lb_cuisne,
                                 Notation = note.Note
                             };

                return result.ToList();
            }
        }

        public IEnumerable<ViewModelGroupRestaurants> GroupRestaurant(List<ViewModelListerRestaurants> result)
        {
            var gpResult = from r_restaurant in result
                           group r_restaurant by r_restaurant.Id into gp
                           select new ViewModelGroupRestaurants()
                           {
                               Id = gp.Key,
                               Nom = gp.FirstOrDefault().Nom,
                               Ville = gp.FirstOrDefault().Ville,
                               Notation = gp.Sum(s => s.Notation),
                               ListCuisine = gp.Select(s => s.StrCuisine).ToList()
                           };
            return gpResult;
        }


        public ViewModelDetailRestaurants DetailsRestaurantByList (int id)
        {
            using(var db = new RestaurantDbContext())
            {
                var details = from restaurant in db.db_restaurants
                              from cuisine in restaurant.TypeCuisines
                              from note in restaurant.Notations
                              join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                              join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                              where restaurant.Id_Restaurant == id
                              select new ViewModelDetailRestaurants()
                              {
                                  Id = restaurant.Id_Restaurant,
                                  Nom = restaurant.lb_nom,
                                  Notation = note.Note,
                                  Adresse = addresse.lb_rue,
                                  CP = addresse.lb_codepostal,
                                  Ville = ville.lb_ville
                              };

                return details.FirstOrDefault();

            }
        }

        public ViewModelDetailRestaurants DetailsRestaurantBySearch(string s_nom, string s_rue, string s_ville_cp)
        {
            using (var db = new RestaurantDbContext())
            {
                var details = from restaurant in db.db_restaurants
                              from cuisine in restaurant.TypeCuisines
                              from note in restaurant.Notations
                              join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                              join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                              let ville_cp = addresse.lb_codepostal.Trim().ToLower() + " " + ville.lb_ville.Trim().ToLower()
                              where restaurant.isActive && restaurant.lb_nom.Trim().ToLower().Equals(s_nom.Trim().ToLower())
                              && addresse.lb_rue.Trim().ToLower().Equals(s_rue.Trim().ToLower())
                              && ville_cp.Equals(s_ville_cp.Trim().ToLower())
                              select new ViewModelDetailRestaurants()
                              {
                                  Id = restaurant.Id_Restaurant,
                                  Nom = restaurant.lb_nom,
                                  Notation = note.Note,
                                  Adresse = addresse.lb_rue,
                                  CP = ville_cp,
                              };

                return details.FirstOrDefault();

            }
        }
    }

}

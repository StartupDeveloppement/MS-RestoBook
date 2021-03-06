﻿using RestoBook.DAL;
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
                var result = (from restaurant in db.db_restaurants
                              from cuisine in restaurant.TypeCuisines
                              from note in restaurant.Notations
                              join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                              join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                              join picture in db.db_Picture on restaurant.Id_Restaurant equals picture.fk_Restaurant
                              where restaurant.isActive && picture.active && picture.role.Equals("header")  && (restaurant.lb_nom.ToLower().Trim().Equals(search.ToLower().Trim())
                              
                             || addresse.lb_rue.ToLower().Trim().Equals(search.ToLower().Trim())
                             || addresse.lb_codepostal.ToLower().Trim().Equals(search.ToLower().Trim())
                             || ville.lb_ville.ToLower().Trim().Equals(search.ToLower().Trim()))
                             || cuisine.lb_cuisne.ToLower().Trim().Equals(search.ToLower().Trim())
                             select new ViewModelListerRestaurants()
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom,
                                 Ville = ville.lb_ville,
                                 IdCuisine = cuisine.Id_Cuisine,
                                 StrCuisine = cuisine.lb_cuisne,
                                 Notation = note.Note,
                                 BytePicture = picture.lb_Picure,
                                 NamePicture = picture.lb_Name,
                             }).Distinct();

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
                               ListCuisine = gp.Select(s => s.StrCuisine).ToList(),
                               //DictCuisine = gp.Select(s => new { s.IdCuisine, s.StrCuisine }).ToDictionary(m => m.IdCuisine, m => m.StrCuisine),
                               NamePicture = gp.FirstOrDefault().NamePicture,
                               BytePicture = gp.FirstOrDefault().BytePicture,
                           };
            return gpResult;
        }


       public ViewModelDetailRestaurants DetailsRestaurantByList (int? id)
        {
            using(var db = new RestaurantDbContext())
            {
                #region 
                //var details = from restaurant in db.db_restaurants
                //              from cuisine in restaurant.TypeCuisines
                //              from note in restaurant.Notations
                //              join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                //              join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                //              where restaurant.Id_Restaurant == id
                //              select new ViewModelDetailRestaurants()
                //              {
                //                  Id = restaurant.Id_Restaurant,
                //                  Nom = restaurant.lb_nom,
                //                  Notation = note.Note,
                //                  Adresse = addresse.lb_rue,
                //                  CP = addresse.lb_codepostal,
                //                  Ville = ville.lb_ville,
                //                  Cuisine = cuisine.lb_cuisne,
                //                  Phone=restaurant.lb_tel,
                //                  WebSite=restaurant.lb_web,
                //              };
                #endregion
                var details = from restaurant in db.db_restaurants
                              from cuisine in restaurant.TypeCuisines
                              from note in restaurant.Notations
                              join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                              join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                              join picture in db.db_Picture on restaurant.Id_Restaurant equals picture.fk_Restaurant
                              where restaurant.Id_Restaurant == id && picture.active
                              select new
                              {
                                  Id = restaurant.Id_Restaurant,
                                  Nom = restaurant.lb_nom,
                                  Notation = note.Note,
                                  Adresse = addresse.lb_rue,
                                  CP = addresse.lb_codepostal,
                                  Ville = ville.lb_ville,
                                  Cuisine = cuisine.lb_cuisne,
                                  Phone = restaurant.lb_tel,
                                  WebSite = restaurant.lb_web,
                                  Description = restaurant.lb_description,
                                  BytePicture = picture.lb_Picure,
                                  NamePicture = picture.lb_Name,
                                  Role = picture.role
                              };

                var group_details = from gpRestaurant in details
                                    group gpRestaurant by gpRestaurant.Id into gp
                                    select new ViewModelDetailRestaurants()
                                    {
                                        Id = gp.Key,
                                        Nom = gp.FirstOrDefault().Nom,
                                        Ville = gp.FirstOrDefault().Ville,
                                        Notation = gp.Sum(s => s.Notation)/gp.Count(),
                                        Adresse = gp.FirstOrDefault().Adresse,
                                        CP = gp.FirstOrDefault().CP,
                                        Cuisine = gp.Select(s => s.Cuisine).ToList(),
                                        Phone = gp.FirstOrDefault().Phone,
                                        WebSite = gp.FirstOrDefault().WebSite,
                                        Description = gp.FirstOrDefault().Description,
                                        BytePicture = gp.Select(s => s.BytePicture).ToList(),
                                        NamePicture = gp.Select(s => s.NamePicture).ToList(),
                                        Roles = gp.Select(s => s.Role).ToList(),
                                    };


                return group_details.FirstOrDefault();

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
                              join picture in db.db_Picture on restaurant.Id_Restaurant equals picture.fk_Restaurant
                              let ville_cp = addresse.lb_codepostal.Trim().ToLower() + " " + ville.lb_ville.Trim().ToLower()
                              where restaurant.isActive && picture.active && restaurant.lb_nom.Trim().ToLower().Equals(s_nom.Trim().ToLower()) //|| picture.active
                              && addresse.lb_rue.Trim().ToLower().Equals(s_rue.Trim().ToLower())
                              && ville_cp.Equals(s_ville_cp.Trim().ToLower())
                              select new
                              {
                                  Id = restaurant.Id_Restaurant,
                                  Nom = restaurant.lb_nom,
                                  Notation = note.Note,
                                  Adresse = addresse.lb_rue,
                                  CP = ville_cp,
                                  Ville = ville.lb_ville,
                                  Cuisine = cuisine.lb_cuisne,
                                  Phone = restaurant.lb_tel,
                                  WebSite = restaurant.lb_web,
                                  Description = restaurant.lb_description,
                                  BytePicture = picture.lb_Picure,
                                  NamePicture = picture.lb_Name,
                                  Role = picture.role
                              };

                var group_details = from gpRestaurant in details
                                    group gpRestaurant by gpRestaurant.Id into gp
                                    select new ViewModelDetailRestaurants()
                                    {
                                        Id = gp.Key,
                                        Nom = gp.FirstOrDefault().Nom,
                                        Ville = gp.FirstOrDefault().Ville,
                                        Notation = gp.Sum(s => s.Notation)/gp.Count(),
                                        Adresse = gp.FirstOrDefault().Adresse,
                                        CP = gp.FirstOrDefault().CP,
                                        Cuisine = gp.Select(s => s.Cuisine).ToList(),
                                        Phone = gp.FirstOrDefault().Phone,
                                        WebSite = gp.FirstOrDefault().WebSite,
                                        Description = gp.FirstOrDefault().Description,
                                        BytePicture = gp.Select(s => s.BytePicture).ToList(),
                                        NamePicture = gp.Select(s => s.NamePicture).ToList(),
                                        Roles = gp.Select(s => s.Role).ToList(),

                                    };
                return group_details.FirstOrDefault();
            }
        }

        public List<ViewModelListerRestaurants> ListerRestaurantByCuisine(int id)
        {
            using (var db =new RestaurantDbContext())
            {
                var result = from restaurant in db.db_restaurants
                             from cuisine in restaurant.TypeCuisines
                             from note in restaurant.Notations
                             join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                             //join picture in db.db_Picture on restaurant.Id_Restaurant equals picture.fk_Restaurant
                             join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                             where restaurant.isActive && cuisine.Id_Cuisine == id //|| picture.active
                             select new ViewModelListerRestaurants()
                             {
                                 Id = restaurant.Id_Restaurant,
                                 Nom = restaurant.lb_nom,
                                 Ville = ville.lb_ville,
                                 IdCuisine = cuisine.Id_Cuisine,
                                 StrCuisine = cuisine.lb_cuisne,
                                 Notation = note.Note
                             };

                return result.ToList();
            }
        }
    }

}

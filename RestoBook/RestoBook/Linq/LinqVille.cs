﻿using RestoBook.DAL;
using RestoBook.Models;
using RestoBook.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RestoBook.Linq
{
    public class LinqVille
    {

        public  List<ViewModelVille> GetVilleByValue(string search)
        {
            using (var db = new RestaurantDbContext())
            {
                var lbVille = from ville in db.db_ville
                               where ville.lb_ville.ToLower().Trim().Contains(search.ToLower().Trim())
                               select new ViewModelVille()
                               {
                                   Id = ville.Id_Ville,
                                   Ville = ville.lb_ville,
                               };
                return  lbVille.ToList();

            }
        }

        public Ville GetVilleFirst(string search)
        {
            using (var db = new RestaurantDbContext())
            {
                var lbVille = (from ville in db.db_ville
                               where ville.lb_ville.ToLower().Trim().Contains(search.ToLower().Trim())
                               select ville).FirstOrDefault();

                return lbVille;

            }
        }

    }
}
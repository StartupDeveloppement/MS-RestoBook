using RestoBook.DAL;
using RestoBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestoBook.Linq
{
    public class LinqCuisine
    {
        public List<TypeCuisine> GetAllCuisine()
        {
            using (var db = new RestaurantDbContext())
            {
                var lbCuisine = from cuisine in db.db_typecuisine
                                orderby cuisine.lb_cuisne ascending
                                select cuisine;
                return  lbCuisine.ToList();
            }
        }

        public TypeCuisine GetCuisineFirst(int id)
        {
            using (var db = new RestaurantDbContext())
            {
                var lbCuisine = (from cuisine in db.db_typecuisine
                                where cuisine.Id_Cuisine==id
                                select cuisine).FirstOrDefault();
                return lbCuisine;
            }
        }
    }
}

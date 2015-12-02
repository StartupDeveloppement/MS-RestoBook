using RestoBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Linq
{
    public class LinqNoteEvaluation
    {

        public int getNbDelicieux(int id)
        {
            using (var db = new RestaurantDbContext())
            {
                int nbDelicieux = (from restaurant in db.db_restaurants
                                 from note in restaurant.Notations
                                 where restaurant.Id_Restaurant == id && note.Note==5
                                 select note).Count();
                return nbDelicieux;

            }
        }

        public int getNbBon(int id)
        {
            using (var db = new RestaurantDbContext())
            {
                int nbBon = (from restaurant in db.db_restaurants
                                   from note in restaurant.Notations
                                   where restaurant.Id_Restaurant == id && note.Note == 4
                                   select note).Count();

                return nbBon;

            }
        }

        public int getNbAcceptable(int id)
        {
            using (var db = new RestaurantDbContext())
            { 
                int nbAcceptable = (from restaurant in db.db_restaurants
                             from note in restaurant.Notations
                             where restaurant.Id_Restaurant == id && note.Note == 3 
                             select note).Count();

                return nbAcceptable;

            }
        }

        public int getNbPassable(int id)
        {
            using (var db = new RestaurantDbContext())
            {
                int nbPassable = (from restaurant in db.db_restaurants
                                    from note in restaurant.Notations
                                    where restaurant.Id_Restaurant == id && note.Note == 2
                                    select note).Count();

                return nbPassable;

            }
        }

        public int getNbMauvais(int id)
        {
            using (var db = new RestaurantDbContext())
            {
                int nbMauvais = (from restaurant in db.db_restaurants
                                  from note in db.db_notation
                                  where restaurant.Id_Restaurant == id && note.Note == 1
                                  select note).Count();

                return nbMauvais;

            }
        }
    }
}

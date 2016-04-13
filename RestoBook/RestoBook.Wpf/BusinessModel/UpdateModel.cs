using RestoBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoBook.Common.Anonymous_Class;

namespace RestoBook.BusinessModel
{
    class UpdateModel
    {
        public static void Update(InfoRestaurant lstInfoRestaurant,byte[] img,string name)
        {
            using (var model = new RestoBookEntities())
            {
                var image = new Picture();
                var restaurants = model.Restaurants.Find(lstInfoRestaurant.Id);
                var addresse = model.Adresse.Find(restaurants.Id_Restaurant);
                addresse.lb_codepostal = lstInfoRestaurant.Cp;
                addresse.lb_rue = lstInfoRestaurant.Rue;
                restaurants.lb_nom = lstInfoRestaurant.Nom;
                restaurants.isActive = lstInfoRestaurant.Active;
                image.lb_Name = name;
                image.lb_Picure = img;
                restaurants.Picture.Add(image);
                restaurants.Adresse.Add(addresse);
                model.Entry(restaurants).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
            }
        }
    }
}

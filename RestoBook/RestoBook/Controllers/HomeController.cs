using RestoBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestoBook.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AutoCompleteGetSearch(string term)
        {

            //List<AutoCompleteSearch> lbville = (from ville in db.db_ville
            //                            where ville.lb_ville.ToLower().Contains(term.ToLower())
            //                            select new AutoCompleteSearch
            //                            {
            //                                Str_Ville = ville.lb_ville
            //                            }).ToList();

            List<AutoCompleteSearchVille> lbville = (from ville in db.db_ville
                                                     where ville.lb_ville.ToLower().Contains(term.ToLower())
                                                     select new AutoCompleteSearchVille
                                                     {
                                                         Ville = ville.lb_ville,
                                                     }).ToList();


            List<AutoCompleteSearchRestaurant> lbrestaurant = (from restaurant in db.db_restaurants
                                                               join addr in db.db_addresse on restaurant.Id_Restaurant equals addr.RestaurantsId
                                                               join ville in db.db_ville on addr.VilleId equals ville.Id_Ville
                                                               where restaurant.lb_nom.ToLower().Contains(term.ToLower())
                                                               || addr.lb_rue.ToLower().Contains(term.ToLower())
                                                               || addr.lb_codepostal.ToLower().Contains(term.ToLower())
                                                               || ville.lb_ville.ToLower().Contains(term.ToLower())
                                                               select new AutoCompleteSearchRestaurant
                                                               {
                                                                   Nom = restaurant.lb_nom,
                                                                   Adresse = addr.lb_rue + ", " + addr.lb_codepostal + " " + ville.lb_ville,
                                                               }).ToList();


            var result = lbville.Union<object>(lbrestaurant);

            //var result = from restaurant in db.db_restaurants
            //             join addr in db.db_addresse on restaurant.Id_Restaurant equals addr.RestaurantsId
            //             join ville in db.db_ville on addr.VilleId equals ville.Id_Ville
            //             where restaurant.lb_nom.ToLower().Contains(term.ToLower())
            //             || addr.lb_rue.ToLower().Contains(term.ToLower())
            //             || addr.lb_codepostal.ToLower().Contains(term.ToLower())
            //             || ville.lb_ville.ToLower().Contains(term.ToLower())
            //             select new AutoCompleteSearch
            //             {
            //                 Nom = restaurant.lb_nom,
            //                 Adresse = addr.lb_rue + ", " + addr.lb_codepostal + " " + ville.lb_ville,
            //                 Ville = ville.lb_ville,
            //             };



            //var gpSearch = (from search in result
            //                group search by search.Ville into gp
            //                select new AutoCompleteSearchGroup
            //                {
            //                    Key = gp.Key,
            //                    AutoCompleteSearch = gp
            //                }).ToList();


            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
    }
}
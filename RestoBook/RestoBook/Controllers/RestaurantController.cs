using RestoBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace RestoBook.Controllers
{
    public class RestaurantController : Controller
    {
        public RestaurantDbContext db = new RestaurantDbContext();

        public async Task<IEnumerable<TypeCuisine>> GetAllCuisineList()
        {
            var type_cuisine = db.db_typecuisine.OrderBy(o => o.lb_cuisne);
            return await type_cuisine.ToListAsync();
        }

        public async Task<List<Ville>> GetSearchVilleList(string searchVille)
        {
            var villes = db.db_ville.OrderBy(o => o.lb_ville).Where(w => w.lb_ville.ToLower().Contains(searchVille.ToLower()));
            return await villes.ToListAsync();
        }

        public async Task<JsonResult> AutoCompleteGetVille(string term)
        {
            List<Ville> lstVille = await GetSearchVilleList(term);
            var result = lstVille.Select(s => s.lb_ville);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: Restaurant
        public async Task<ActionResult> Proposer()
        {
            ViewModelRestaurant m_view = new ViewModelRestaurant();
            m_view.ItemsCuisine = await GetAllCuisineList();
            if (m_view.ItemsCuisine.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(m_view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Proposer(ViewModelRestaurant model, bool EmptyVille)
        {
            if (ModelState.IsValid)
            {
                Restaurants view_newRestaurant = model.m_restaurant;
                Ville view_ville = model.m_ville;
                Adresse view_addresse = model.m_adresse;

                var existingRestaurant = from restaurant in db.db_restaurants
                                         join addr in db.db_addresse on restaurant.Id_Restaurant equals addr.RestaurantsId
                                         join ville in db.db_ville on addr.VilleId equals ville.Id_Ville
                                         where restaurant.lb_nom.ToLower().Equals(view_newRestaurant.lb_nom.ToLower())
                                         && addr.lb_rue.ToLower().Equals(view_addresse.lb_rue.ToLower())
                                         && addr.lb_codepostal.ToLower().Equals(view_addresse.lb_codepostal.ToLower())
                                         && ville.lb_ville.ToLower().Equals(view_ville.lb_ville.ToLower())
                                         select restaurant;

                if (existingRestaurant.Count() > 0)
                    return RedirectToAction("Index", "Home");

                List<Ville> lstVille = await GetSearchVilleList(view_ville.lb_ville.ToLower());
                Ville existingCity = lstVille.FirstOrDefault();

                if ((EmptyVille) && existingCity == null)
                {
                    view_ville.lb_ville = char.ToUpper(view_ville.lb_ville[0]) + view_ville.lb_ville.Substring(1);
                    view_addresse.lb_rue = view_addresse.lb_rue.Replace(",", "");
                    db.db_ville.Add(view_ville);
                    db.db_addresse.Add(view_addresse);
                }
                else
                {
                    view_addresse.lb_rue = view_addresse.lb_rue.Replace(",", "");
                    db.db_ville.Attach(existingCity);
                    existingCity.Adresses.Add(view_addresse);
                }
              
                foreach (string typeCuisine in model.SelectedItemsCuisine)
                {
                    IEnumerable<TypeCuisine> lstCuisine = await GetAllCuisineList();

                    if (lstCuisine.Count() == 0)
                    {
                        return HttpNotFound();
                    }

                    TypeCuisine existingCuisine = lstCuisine.FirstOrDefault(x => x.Id_Cuisine == int.Parse(typeCuisine));
                    db.db_typecuisine.Attach(existingCuisine);
                    existingCuisine.Restaurants.Add(view_newRestaurant);
                }

                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            model.ItemsCuisine = await GetAllCuisineList();

            if (model.ItemsCuisine.Count() == 0)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        public ActionResult Lister(string SearchString, int? page)
        {
            string[] splitSearchString = SearchString.Split(',');
            string search_1 = splitSearchString[0];
            string search_2 = string.Empty; 
            string search_3 = string.Empty; 

            if (splitSearchString.Count() > 1)
            {
                search_2 = splitSearchString[1];
                search_3 = splitSearchString[2];
            }
            else
            {
                search_2 = search_1;
                search_3 = search_1;
            }

            List<ListerRestaurants> result = (from restaurant in db.db_restaurants
                        from cuisine in restaurant.TypeCuisines
                        join addresse in db.db_addresse on restaurant.Id_Restaurant equals addresse.RestaurantsId
                        join ville in db.db_ville on addresse.VilleId equals ville.Id_Ville
                        where restaurant.lb_nom.ToLower().Equals(search_1.ToLower())
                        || addresse.lb_rue.ToLower().Equals(search_2.ToLower())
                        || addresse.lb_codepostal.ToLower().Equals(search_3.ToLower())
                        || ville.lb_ville.ToLower().Equals(search_3.ToLower())
                                              select new ListerRestaurants()
                         {
                             Id = restaurant.Id_Restaurant,
                             Nom = restaurant.lb_nom,
                             Ville = ville.lb_ville,
                             StrCuisine = cuisine.lb_cuisne
                         }).ToList();

            List<ListerRestaurants> gpResult =(from r_restaurant in result
                           group r_restaurant by r_restaurant.Id into gp
                           select new ListerRestaurants()
                           {
                               Id = gp.Key,
                               Nom = gp.FirstOrDefault().Nom,
                               Ville = gp.FirstOrDefault().Ville,
                               //StrCuisine = gp.Select(s => s.StrCuisine).Aggregate((i, j) => i + ",  " + j),
                               ListCuisine = gp.Select(s=>s.StrCuisine).ToList()
                           }).ToList();

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(gpResult.ToPagedList(pageNumber, pageSize));
            //return View(gpResult);

        }

        #region oldRequest
        //public List<Ville> GetAllVilleList()
        //{
        //    var villes = db.db_ville.OrderBy(o => o.lb_ville);
        //    return villes.ToList();
        //}

        //public List<Ville> GetAllVilleList()
        //{
        //    var villes = db.db_ville.OrderBy(o => o.lb_ville);
        //    return villes.ToList();
        //}

        //public JsonResult AutoCompleteGetVille(string term)
        //{
        //    var result = GetAllVilleList().Where(w => w.lb_ville.ToLower().Contains(term.ToLower())).Select(s => s.lb_ville);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public IEnumerable<TypeCuisine> GetAllCuisineList()
        //{
        //    var type_cuisine = db.db_typecuisine.OrderBy(o => o.lb_cuisne).ToList();
        //    return type_cuisine;
        //}
        #endregion
    }
}
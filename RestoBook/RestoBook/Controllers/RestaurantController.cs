using RestoBook.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using RestoBook.DAL;
using RestoBook.Linq;
using RestoBook.Models.ViewModels;

namespace RestoBook.Controllers
{
    public class RestaurantController : Controller
    {
        public JsonResult AutoCompleteGetVille(string term)
        {
            LinqVille linqVille = new LinqVille();
            var result = linqVille.GetVilleByValue(term);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Restaurant
        public ActionResult Proposer()
        {
            ViewModelAddRestaurant m_view = new ViewModelAddRestaurant();
            LinqCuisine linqCuisine = new LinqCuisine();
            m_view.ItemsCuisine = linqCuisine.GetAllCuisine();
            return View(m_view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Proposer(ViewModelAddRestaurant model, bool EmptyVille)
        {
            LinqCuisine linqCuisine = new LinqCuisine();

            if (ModelState.IsValid)
            {
                Restaurants view_newRestaurant = model.m_restaurant;
                Ville view_ville = model.m_ville;
                Adresse view_addresse = model.m_adresse;
                Notation view_notation = model.m_notation;

                view_newRestaurant.lb_nom = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(view_newRestaurant.lb_nom);

                LinqRestaurant linqRestautant = new LinqRestaurant();

                int result = linqRestautant.ExistRestaurant(view_newRestaurant.lb_nom, view_addresse.lb_rue, view_addresse.lb_codepostal, view_ville.lb_ville);

                if (result>0)
                    return RedirectToAction("Index", "Home");

                LinqVille linqVille = new LinqVille();
                var existingCity = linqVille.GetVilleFirst(view_ville.lb_ville.ToLower());

                using(var db = new RestaurantDbContext())
                {
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
                        TypeCuisine existingCuisine = linqCuisine.GetCuisineFirst(int.Parse(typeCuisine));
                        db.db_typecuisine.Attach(existingCuisine);
                        existingCuisine.Restaurants.Add(view_newRestaurant);
                    }

                    view_newRestaurant.Notations.Add(view_notation);

                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }

            model.ItemsCuisine = linqCuisine.GetAllCuisine();

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult _Filter()
        {
            ViewModelFilter filter = new ViewModelFilter();
            LinqCuisine linqCuisine = new LinqCuisine();
            var result = linqCuisine.GetAllCuisine();
            List<ViewModelFilter> lstFilterCuisine = new List<ViewModelFilter>();
            foreach (var item in result)
            {
                lstFilterCuisine.Add(
                    new ViewModelFilter() { Checked = false, Id=item.Id_Cuisine,Value=item.lb_cuisne }
                );
            }
            return PartialView(lstFilterCuisine);
        }

        public ActionResult Lister(string search, string currentFilter, int? page)
        {
            LinqRestaurant linqRestaurant = new LinqRestaurant();

            int pageSize = 2;
            int pageNumber = (page ?? 1);

            if (TempData["Search"] != null && TempData["ResultSearch"] != null)
            {
                ViewBag.CurrentFilter = TempData["Search"];
                var result = (IEnumerable<ViewModelGroupRestaurants>)TempData["ResultSearch"];
                return View(result.ToPagedList(pageNumber, pageSize));
            }

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            if (!string.IsNullOrEmpty(search))
            {
                var listerRestaurant = linqRestaurant.ListerRestaurants(search);
                var gpRestaurant = linqRestaurant.GroupRestaurant(listerRestaurant);
                return View(gpRestaurant.ToPagedList(pageNumber, pageSize));
            }

            return RedirectToAction("Index","Home");
        }

        //public ActionResult ListerRestaurantCuisine(int id,int? page)
        //{
        //    LinqRestaurant linqRestaurant = new LinqRestaurant();
        //    int pageSize = 2;
        //    int pageNumber = (page ?? 1);
        //    var lsrestaurantcuisine = linqRestaurant.ListerRestaurantByCuisine(id);
        //    var gpRestaurant = linqRestaurant.GroupRestaurant(lsrestaurantcuisine);
        //    return View(gpRestaurant.ToPagedList(pageNumber,pageSize));
        //}

        public ActionResult Details(int? id)
        {
            LinqRestaurant linqRestaurant = new LinqRestaurant();
            LinqNoteEvaluation linqEvaluation = new LinqNoteEvaluation();
            ViewModelDetailRestaurants model_details = new ViewModelDetailRestaurants();
            ViewModelAllDetailRestaurants model_Alldetails = new ViewModelAllDetailRestaurants();
            ViewModelEvaluation model_evaluation = new ViewModelEvaluation();

            if (TempData["RestaurantSearch"]!=null)
            {
                model_details = (ViewModelDetailRestaurants)TempData["RestaurantSearch"];
            }
            else
            {
                //model_details = linqRestaurant.DetailsRestaurantByList(id);
                model_details = linqRestaurant.DetailsRestaurantByList(id);

            }

            model_evaluation.nbDelicieux = linqEvaluation.getNbDelicieux(model_details.Id);
            model_evaluation.percentDelicieux = (model_evaluation.nbDelicieux * 100) / 1;

            model_evaluation.nbBon = linqEvaluation.getNbBon(model_details.Id);
            model_evaluation.percentBon = (model_evaluation.nbBon * 100) / 1;

            model_evaluation.nbAcceptable = linqEvaluation.getNbAcceptable(model_details.Id);
            model_evaluation.percentAcceptable = (model_evaluation.nbAcceptable * 100) / 1;

            model_evaluation.nbPassable = linqEvaluation.getNbPassable(model_details.Id);
            model_evaluation.percentPassable = (model_evaluation.nbPassable * 100) / 1;

            model_evaluation.nbMauvais = linqEvaluation.getNbPassable(model_details.Id);
            model_evaluation.percentMauvais = (model_evaluation.nbMauvais * 100) / 1;

            model_Alldetails.detailRestautants = model_details;
            model_Alldetails.evaluationlRestautants = model_evaluation;

            return View(model_Alldetails);
        }
    } 
}
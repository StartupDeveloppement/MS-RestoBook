using RestoBook.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RestoBook.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string SearchString)
        {
            LinqRestaurant linqRestaurant = new LinqRestaurant();

            TempData["Search"] = SearchString;

            if (!string.IsNullOrEmpty(SearchString))
            {
                if (SearchString.IndexOf(",") != -1)
                {
                    string[] splitSarchRestaurant = SearchString.Split(',');
                    var detailsRestaurants = linqRestaurant.DetailsRestaurantBySearch(splitSarchRestaurant[0], splitSarchRestaurant[1], splitSarchRestaurant[2]);
                    TempData["RestaurantSearch"] = detailsRestaurants;
                    return RedirectToAction("Details", "Restaurant", new { id = detailsRestaurants.Id });
                }
                else
                { 
                    var listerRestaurant = linqRestaurant.ListerRestaurants(SearchString);
                    var gpRestaurant = linqRestaurant.GroupRestaurant(listerRestaurant);
                    TempData["ResultSearch"] = gpRestaurant;
                    return RedirectToAction("Lister", "Restaurant", new { search = SearchString });
                }
            }

            return View();
        }

        public JsonResult AutoCompleteGetSearch(string term)
        {
            LinqRestaurant linqRestaurant = new LinqRestaurant();
            LinqVille linqVille = new LinqVille();
            var resultVille = linqVille.GetVilleByValue(term.ToLower());
            var resultRestaurant = linqRestaurant.Search(term.ToLower());
            var result = resultVille.Union<object>(resultRestaurant);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
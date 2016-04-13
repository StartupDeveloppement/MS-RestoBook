using RestoBook.Linq;
using RestoBook.Models;
using RestoBook.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;

namespace RestoBook.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            //List<ViewModelVille> viewModelVille = new List<ViewModelVille>();
            List<ViewModelVille>lstBigVille = new List<ViewModelVille>()
            {
                (new ViewModelVille { Id=1,Ville="Paris",Img="home_paris.png"}),
                (new ViewModelVille { Id=2,Ville="Lyon",Img="home_lyon.png"}),
                (new ViewModelVille { Id=3,Ville="Toulouse",Img="home_toulouse.png"}),
                (new ViewModelVille { Id=4,Ville="Bordeaux",Img="home_bordeaux.png"}),
                (new ViewModelVille { Id=5,Ville="Marseille",Img="home_marseille.png"}),
                (new ViewModelVille { Id=6,Ville="Lille",Img="home_lille.png"}),
            };

            return View(lstBigVille.OrderBy(ob=>ob.Ville));
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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.From = new MailAddress(model.FromEmail);
                message.To.Add(new MailAddress("ingesup.test@gmail.com"));
                message.Body = model.Message;
                message.Subject = "Contact";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("ingesup.test@gmail.com", "ingesuptest");

                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            else
                return View();
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}
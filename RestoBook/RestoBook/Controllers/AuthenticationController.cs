using Microsoft.AspNet.Identity;
using RestoBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using RestoBook.Bean;
//using RestoBook.Entity;


namespace RestoBook.Controllers
{
    public class AuthenticationController : Controller
    {

        //    private static User mod = new User();
        //    private RestoBook.Entity.RoleProvider roleProvider = new RestoBook.Entity.RoleProvider();
        //    private DBContext db = new DBContext();
        //    // GET: Authentication
        //    public ActionResult Login()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    [AllowAnonymous]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Login(LoginViewModel model, string returnUrl)
        //    {
        //        ViewBag.ReturnUrl = returnUrl;

        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }
        //        if (!ValidateUser(model.Login, model.Password))
        //        {
        //            ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
        //            return View(model);
        //        }
        //        var loginClaim = new Claim(ClaimTypes.NameIdentifier, model.Login);
        //        var claimsIdentity = new ClaimsIdentity(new[] { loginClaim }, DefaultAuthenticationTypes.ApplicationCookie);
        //        var ctx = Request.GetOwinContext();
        //        var authenticationManager = ctx.Authentication;
        //        authenticationManager.SignIn(claimsIdentity);

        //        // Rediriger vers l'URL d'origine :
        //        if (Url.IsLocalUrl(ViewBag.ReturnUrl))
        //            return Redirect(ViewBag.ReturnUrl);
        //        // Par défaut, rediriger vers la page d'accueil :
        //        return RedirectToAction("Index", "Home");

        //    }
        //    private bool ValidateUser(string login, string password)
        //    {
        //        // TODO : insérer ici la validation des identifiant et mot de passe de l'utilisateur...

        //        // Pour ce tutoriel, j'utilise une validation extrêmement sécurisée...
        //        return login == password;
        //    }
        //    [HttpGet]
        //    public ActionResult Logout()
        //    {
        //        var ctx = Request.GetOwinContext();
        //        var authenticationManager = ctx.Authentication;
        //        authenticationManager.SignOut();

        //        // Rediriger vers la page d'accueil :
        //        return RedirectToAction("Index", "Home");
        //    }
        //    public User AjouterUtilisateur(string lastName, string firstName, string password, string email)
        //    {
        //        string passwordHash = HashPassword(password);
        //        User utilisateur = new User { FirstName = firstName, LastName = lastName, Email = email, Password = passwordHash };
        //        db.User.Add(utilisateur);
        //        db.SaveChanges();
        //        return utilisateur;
        //    }

        //    private string HashPassword(string password)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    [HttpPost]
        //    public async Task<ActionResult> Register(RegisterModel utilisateur)
        //    {
        //        utilisateur.Password = getPasswordForUser();

        //        if (ModelState.IsValid)
        //        {
        //            string password = utilisateur.Password;
        //            User currentUser = GetCurrentUser();
        //            int currentUserRole = roleProvider.GetRoleForUser(currentUser);
        //            if (currentUserRole != 1)
        //            {
        //                return RedirectToAction("index", "home");
        //            }
        //            bool isExist = IsExistUser(utilisateur.Email);
        //            if (isExist == false)
        //            {
        //                ModelState.AddModelError("", "Adresse mail déjà utilisée");
        //                return View();
        //            }
        //            User user = AjouterUtilisateur(utilisateur.LastName, utilisateur.FirstName, utilisateur.Password, utilisateur.Email);

        //            //UserRole userRole = new UserRole();
        //            //userRole.IdUser = user.Id;
        //            //userRole.Roles = roleProvider.GetRoleById(2);
        //            //db.UserRole.Add(userRole);
        //            //db.SaveChanges();
        //            //var requete = from b in db.User
        //            //              where b.Email.Equals(utilisateur.Email)
        //            //              select b;
        //            //mod = requete.First();
        //            return RedirectToAction("InfoUtilisateur", new { password = password });

        //        }
        //        return View(utilisateur);
        //    }
        //    public User GetCurrentUser()
        //    {
        //        var currentUser = HttpContext.User.Identity.Name;

        //        var userRequete = from b in db.User
        //                          where b.Email.Equals(currentUser)
        //                          select b;
        //        return userRequete.FirstOrDefault();
        //    }
        //    public ActionResult Register()
        //    {
        //        return View();
        //    }
        //    public bool IsExistUser(string email)
        //    {

        //        User userToTest = db.User.FirstOrDefault(u => u.Email == email);
        //        if (userToTest == null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //     public int GetRoleForUser()
        //    {
        //        var userid = HttpContext.User.Identity.GetUserId();

        //        var currentUser = from b in db.UserRole
        //                          where b.IdUser.Equals(userid)
        //                          select b.Roles;
        //        var resu = currentUser.FirstOrDefault<int>();

        //        if (resu != null)
        //        {
        //            return resu;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }

        //    public string getPasswordForUser()
        //    {
        //        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //        var stringChars = new char[10];
        //        var random = new Random();

        //        for (int i = 0; i < stringChars.Length; i++)
        //        {
        //            stringChars[i] = chars[random.Next(chars.Length)];
        //        }

        //        return new String(stringChars);
        //    }

    }
}
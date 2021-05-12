using GesProduct.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace GesProduct.Controllers
{
    public class LoginController : Controller
    {
        // GET: Product/Create
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.LoginModel());
        }

        // POST: Login/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginModel login)
        {
            try
            {
                
                // TODO: Add insert logic here
                // Récuperation des donnée saisies
                string Username = HttpContext.Request.Form["Username"];
                string Password = HttpContext.Request.Form["Password"];
                
                //Processus de login
                var client = new RestClient("http://localhost:54120/api/Login");
                var request = new RestRequest(Method.POST);
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(login);
                }

                var response = client.Execute<User>(request);
                User u = response.Data;
                if(u != null)
                {
                    HttpContext.Session.SetString("Username", Username);
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ViewBag.error = "Le compte d'utilisateur n'est pas valide ";
                    return View();

                }

            }
            catch
            {
                ViewBag.error = "Le compte d'utilisateur n'est pas valide ";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Clear();
           // HttpContext.Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}
using CalcuradoraMVC.Models;
using CalcuradoraMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CalcuradoraMVC.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _repository;
        public HomeController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Remove("UserId");
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(User theUser)
        {
            User user = _repository.IsCorrect(theUser);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Calculadora");
            }
            else
            {
                ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrecto";
                return View("Index");
            }

        }

        [HttpGet]
        public IActionResult GetSessionValue()
        {
            int? sessionValue = HttpContext.Session.GetInt32("UserId");
            return Json(sessionValue, new JsonSerializerOptions());
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
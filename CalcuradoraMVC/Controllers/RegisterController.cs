using Microsoft.AspNetCore.Mvc;
using CalcuradoraMVC.Models;
using CalcuradoraMVC.Repositories;
namespace CalcuradoraMVC.Controllers
{
    public class RegisterController : Controller
    {
        private IUserRepository _repository;
        public RegisterController(IUserRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult nuevoUsuario(User theUser)
        {
            if (ModelState.IsValid && _repository.AlreadyExists(theUser) == false)
            {
                _repository.AddUser(theUser);

                HttpContext.Session.SetInt32("UserId", theUser.Id);

                return RedirectToAction("Index", "Calculadora");
            }
            else if(_repository.AlreadyExists(theUser) == true)
            {
                ViewBag.ErrorMessage = "Nombre de usuario ya existente";
                return View("Index");
            }else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ViewBag.ErrorMessage += error.ErrorMessage ;
                }
                return View("Index");
            }
        }
    }
}

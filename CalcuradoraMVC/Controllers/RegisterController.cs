using Microsoft.AspNetCore.Mvc;

namespace CalcuradoraMVC.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

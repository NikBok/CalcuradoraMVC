using CalcuradoraMVC.Models;
using CalcuradoraMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace CalcuradoraMVC.Controllers
{
    public class HistorialController : Controller
    {
        private IHistorialRepository _repository;

        public HistorialController(IHistorialRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            return View(_repository.GetOperations(userId));
        }
        
        public IActionResult Delete(int id)
        {
            _repository.DeleteOperation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

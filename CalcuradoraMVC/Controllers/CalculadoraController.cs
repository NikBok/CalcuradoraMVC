using CalcuradoraMVC.Models;
using CalcuradoraMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace CalcuradoraMVC.Controllers
{
    public class CalculadoraController : Controller
    {
        private IOperationsRepository _repository;

        public CalculadoraController(IOperationsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SaveOperations([FromBody] Operations datos)
        {
            _repository.SaveAnOperation(datos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

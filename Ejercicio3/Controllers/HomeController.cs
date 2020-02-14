using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ejercicio3.Models;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DealerViewModel _dealer;

        public HomeController(ILogger<HomeController> logger)
        {
            _dealer = new DealerViewModel();
            _logger = logger;
        }

        public IActionResult Lista()
        {
            return View(_dealer);
        }

        [HttpPost]
        public IActionResult Formulario(Carro carro)
        {
            var id = _dealer.Carros.Count > 0 ? _dealer.Carros.Max(s => s.Id) + 1 : 0;
            carro.Id = id;
            if (ModelState.IsValid)
            {
                _dealer.Carros.Add(carro);
                return View("Lista", _dealer);
            }
            return View(carro);
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

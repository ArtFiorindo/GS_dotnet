using Microsoft.AspNetCore.Mvc;
using MeasurementApp.Models;
using System.Diagnostics;

namespace MeasurementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // Carrega a view Index de Home
        }

        public IActionResult Privacy()
        {
            return View("Privacy"); // Carrega a view Privacy
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Problem(detail: "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde.",
                statusCode: 500,
                title: "Erro Interno");
        }
    }
}
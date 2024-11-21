using Microsoft.AspNetCore.Mvc;
using MeasurementApp.Models;
using MeasurementApp.Services;

namespace MeasurementApp.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly MeasurementService _measurementService;

        public MeasurementController(MeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        // Lista de medições
        public IActionResult List()
        {
            var measurements = _measurementService.GetAllMeasurements();
            return View(measurements);
        }

        // Criar uma nova medição (GET)
        public IActionResult Create()
        {
            return View(new Measurement());
        }

        // Criar uma nova medição (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Tower,kWh")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                _measurementService.AddMeasurement(measurement);
                return RedirectToAction(nameof(List));
            }
            return View(measurement);
        }

        // Editar uma medição (GET)
        public IActionResult Edit(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        // Editar uma medição (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Tower,kWh")] Measurement measurement)
        {
            if (id != measurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _measurementService.UpdateMeasurement(measurement);
                return RedirectToAction(nameof(List));
            }
            return View(measurement);
        }

        // Excluir uma medição (GET - Exibe a confirmação)
        public IActionResult Delete(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        // Confirmar exclusão (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _measurementService.RemoveMeasurement(id);
            return RedirectToAction(nameof(List));
        }

        // Exibir detalhes de uma medição
        public IActionResult Details(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        // Página de estatísticas (GET)
        public IActionResult TowerStats()
        {
            return View();
        }

        // Método para calcular as porcentagens de consumo por torre (API JSON)
        [HttpGet]
        public IActionResult GetTowerData()
        {
            var measurements = _measurementService.GetAllMeasurements();

            if (measurements == null || !measurements.Any())
            {
                // Retorna uma lista vazia se não houver medições
                return Json(new List<object>());
            }

            // Calcula o consumo total de kWh
            var totalConsumption = measurements.Sum(m => m.kWh);
            if (totalConsumption == 0)
            {
                // Evita divisão por zero
                return Json(new List<object>());
            }

            // Agrupa os dados por torre, calcula o total e a porcentagem
            var data = measurements
                .GroupBy(m => m.Tower)
                .Select(g => new
                {
                    Tower = g.Key.ToString(),
                    TotalkWh = g.Sum(m => m.kWh),
                    Percentage = (g.Sum(m => m.kWh) / totalConsumption) * 100
                })
                .OrderBy(d => d.TotalkWh) // Ordena do menor para o maior consumo
                .ToList();

            return Json(data);
        }
    }
}

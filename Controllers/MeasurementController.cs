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

        public IActionResult List()
        {
            var measurements = _measurementService.GetAllMeasurements();
            return View(measurements);
        }

        public IActionResult Create()
        {
            return View(new Measurement());
        }

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

        public IActionResult Edit(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

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

        public IActionResult Delete(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _measurementService.RemoveMeasurement(id);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Details(int id)
        {
            var measurement = _measurementService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return View(measurement);
        }
    }
}

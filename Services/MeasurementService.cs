using MeasurementApp.Models;
using MeasurementApp.Repositories;
using System.Collections.Generic;

namespace MeasurementApp.Services
{
    public class MeasurementService
    {
        private readonly IRepository<Measurement> _repository;

        public MeasurementService(IRepository<Measurement> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Measurement> GetAllMeasurements()
        {
            return _repository.GetAll();
        }

        public Measurement GetMeasurementById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddMeasurement(Measurement measurement)
        {
            _repository.Add(measurement);
            _repository.Save();
        }

        public void UpdateMeasurement(Measurement measurement)
        {
            _repository.Update(measurement);
            _repository.Save();
        }

        public void RemoveMeasurement(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
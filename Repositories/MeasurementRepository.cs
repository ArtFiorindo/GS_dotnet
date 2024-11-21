using MeasurementApp.Data;
using MeasurementApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeasurementApp.Repositories
{
    public class MeasurementRepository : IRepository<Measurement>
    {
        private readonly AppDbContext _context;

        public MeasurementRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Measurement> GetAll()
        {
            return _context.Measurements.ToList();
        }

        public Measurement GetById(int id)
        {
            return _context.Measurements.Find(id);
        }

        public void Add(Measurement entity)
        {
            _context.Measurements.Add(entity);
        }

        public void Update(Measurement entity)
        {
            _context.Measurements.Update(entity);
        }

        public void Delete(int id)
        {
            var measurement = _context.Measurements.Find(id);
            if (measurement != null)
            {
                _context.Measurements.Remove(measurement);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
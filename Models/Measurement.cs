using System;
using System.ComponentModel.DataAnnotations;

namespace MeasurementApp.Models
{
    public class Measurement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Torre é obrigatória.")]
        public Tower Tower { get; set; }

        [Required(ErrorMessage = "O valor de kWh é obrigatório.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor de kWh deve ser maior que 0.")]
        public double kWh { get; set; }

        public DateTime MeasurementDate { get; set; } = DateTime.Now;
    }

    public enum Tower
    {
        TorreA,
        TorreB,
        TorreC
    }
}
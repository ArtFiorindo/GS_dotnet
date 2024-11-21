using Microsoft.EntityFrameworkCore;
using MeasurementApp.Models;

namespace MeasurementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>().Property(m => m.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Measurement>().Property(m => m.kWh).IsRequired();
            modelBuilder.Entity<Measurement>().Property(m => m.Tower).IsRequired();
            modelBuilder.Entity<Measurement>().Property(m => m.MeasurementDate).HasDefaultValueSql("SYSDATE");

            base.OnModelCreating(modelBuilder);
        }
    }
}
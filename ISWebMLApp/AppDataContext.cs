using ISWebMLApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ISWebMLApp
{
    public class AppDataContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MonitorMeasurement> Measurements { get; set; }
        public DbSet<Structure> Structures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=82.146.56.114;user=external;password=superFinashka;database=ISWebMLApp;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}

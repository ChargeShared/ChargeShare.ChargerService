using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ChargeShare.ChargerService.DAL.Configurations;
using Shared.Models;

namespace ChargeShare.ChargerService.DAL.Contexts
{
    public class ChargerContext : DbContext
    {
        private string connectionString = "TempDB";

        public DbSet<ChargeStationModel> Chargers { get; set; }


        public ChargerContext()
        {

        }

        public ChargerContext(DbContextOptions<ChargerContext> context) : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChargerConfiguration());
        }
    }
}

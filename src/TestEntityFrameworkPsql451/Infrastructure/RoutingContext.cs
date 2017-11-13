using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Models;
using Toolfactory.Database.Dao;

namespace TestEntityFrameworkPsql451.Infrastructure
{
    public class RoutingContext : DbContext
    {
        private readonly string _connectionString;
        private readonly ConnectionList _connectionList;
        public RoutingContext(): base()
        {
            _connectionList = DaoConnections.SingleInstance[lineOfBusiness: Toolfactory.Core.BaseTypes.LineOfBusiness.Architecture, applicationType: Toolfactory.Core.BaseTypes.ApplicationType.Any];
            _connectionString = _connectionList["PG_HUBROUTING", true].ConnectionString;
        }

        public DbSet<HubComponent> HubComponents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HubComponent>(b => {
                b.HasKey(u => u.id_component);
                b.HasIndex(u => u.id_component).HasName("id_component");
                b.ToTable("hub_component");
            });
            
        }

    }
}
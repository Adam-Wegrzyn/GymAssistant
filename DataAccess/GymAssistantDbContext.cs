using DataAccess.Entities;
using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public class GymAssistantDbContext: DbContext
    {
        public GymAssistantDbContext(): base()
        {
                
        }

        public GymAssistantDbContext(DbContextOptions<GymAssistantDbContext> options): base(options)
        {
            
        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingLog> TrainingLogs { get; set; }
        public DbSet<TrainingSession> TrainingSessionss { get; set; }
        public DbSet<TrainingSet> TrainingSets { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingSet>()
                .Property(t => t.Weight).HasColumnType<decimal>("decimal").HasPrecision(1);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
 =>     options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GymAssistantDB;Trusted_connection=true;TrustServerCertificate=true;");
    }

    
}

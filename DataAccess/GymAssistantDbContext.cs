using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public class GymAssistantDbContext: DbContext
    {
        private readonly string _connectionString;
        public GymAssistantDbContext(): base()
        {
                
        }

        public GymAssistantDbContext(DbContextOptions<GymAssistantDbContext> options): base(options)
        {
            
        }

        public GymAssistantDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingLog> TrainingLogs { get; set; }
        public DbSet<TrainingSet> TrainingSets { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingSetExercise> TrainingSetsExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingSet>()
                .Property(t => t.Weight).HasColumnType<decimal>("decimal").HasPrecision(5, 2);
            modelBuilder.Entity<TrainingLog>()
                .Property(t => t.Date).HasColumnType<DateTime>("smalldatetime");
            modelBuilder.Entity<Exercise>()
                          .Property(e => e.MuscleGroup)
                          .HasConversion(new EnumToStringConverter<MuscleGroup>());
        }


    


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                options.UseSqlServer(_connectionString);
            }
            else
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GymAssistantDB;Trusted_connection=true;TrustServerCertificate=true;");
            }
        }

    }

    
}

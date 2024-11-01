using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess;

public class  TestDbContext: GymAssistantDbContext
{
    private readonly string _connectionString;
    public TestDbContext(DbContextOptions<GymAssistantDbContext> options, string connectionString) : base(options) {

        _connectionString = connectionString;
    }

    //public DbSet<Exercise> Exercises { get; set; }
    //public DbSet<Training> Trainings { get; set; }
    //public DbSet<TrainingSet> TrainingSets { get; set; }
    //public DbSet<TrainingSetExercise> TrainingSetExercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<TrainingSet>()
        //    .Property(t => t.Weight).HasColumnType<decimal>("decimal").HasPrecision(5, 2);
        //modelBuilder.Entity<TrainingLog>()
        //    .Property(t => t.Date).HasColumnType<DateTime>("smalldatetime");
        //modelBuilder.Entity<Exercise>()
        //    .Property(e => e.MuscleGroup)
        //                    .HasConversion(
        //        v => v.ToString(),
        //        v => (MuscleGroup)Enum.Parse(typeof(MuscleGroup), v));
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      
            optionsBuilder.UseSqlServer(_connectionString);

    }
}

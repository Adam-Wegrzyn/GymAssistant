using AutoMapper;
using Core.Service;
using Data.Common.DTO;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repository;
using GymAssistant.Tests;
using GymAssistantv2.Server.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Data.Common;
using System.Data;
using Testcontainers.MsSql;
using Xunit;


public class TrainingServiceTests: IAsyncLifetime
{
    private  TestDbContext _context;
    private  IMapper _mapper;
    private  ITrainingService _trainingService;
    private  MsSqlContainer _msSqlContainer;

    public TrainingServiceTests()
    {
        _msSqlContainer = new MsSqlBuilder()
        .WithPassword("yourStrong(!)Password")
        .Build();
    }
    public async Task InitializeAsync()
    {
    //    

        await _msSqlContainer.StartAsync();
        var conn = _msSqlContainer.GetConnectionString();
        var options = new DbContextOptionsBuilder<GymAssistantDbContext>()
           .EnableSensitiveDataLogging()
        .UseSqlServer(_msSqlContainer.GetConnectionString())
        .Options;

        _context = new TestDbContext(options, conn);
        await _context.Database.MigrateAsync();
        await SeedDatabase();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ExerciseDTO, Exercise>().ReverseMap();
            cfg.CreateMap<TrainingDTO, Training>().ReverseMap();
        });

        _mapper = config.CreateMapper();

        var trainingRepository = new TrainingRepository(_context);
        _trainingService = new TrainingService(trainingRepository, _mapper);

    }


    private async Task SeedDatabase()
    {
    //    await ResetDb();
        var exercises = FakeDb.GetFakeExercises();
        var trainings = FakeDb.GetFakeTrainings();

        _context.Exercises.AddRange(exercises);
        _context.Trainings.AddRange(trainings);
        _context.SaveChanges();

    }

    [Fact]
    public void ConnectionStateReturnsOpen()
    {
        var conn = _msSqlContainer.GetConnectionString();
        // Given
        using DbConnection connection = new SqlConnection(_msSqlContainer.GetConnectionString());

        // When
        connection.Open();

        // Then
        Assert.Equal(ConnectionState.Open, connection.State);
    }

    [Fact]
    public async Task AddExercise_AddsExerciseToDatabase()
    {
        // Arrange
        var exerciseDTO = new ExerciseDTO { Name = "Push Up",
            Description = "",
            ImagePath = ""
        };

        // Act
        Exercise addedExercise = await _trainingService.AddExercise(exerciseDTO, CancellationToken.None);
        await _context.SaveChangesAsync();
        // Assert
        var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == addedExercise.Id);
        Assert.NotNull(exercise);
        Assert.Equal("Push Up", exercise.Name);
    }

    [Fact]
    public async Task AddTraining_AddsTrainingToDatabase()
    {
        await _msSqlContainer.StartAsync();
        // Arrange
        var trainingDTO = new TrainingDTO { Name = "Morning Routine" };

        // Act
        var trainingAdded = await _trainingService.AddTraining(trainingDTO, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var training = await _context.Trainings.SingleOrDefaultAsync(e => e.Id == trainingAdded.Id);
        Assert.NotNull(training);
        Assert.Equal("Morning Routine", training.Name);
    }

    [Fact]
    public async Task DeleteExercise_RemovesExerciseFromDatabase()
    {
        // Arrange

        // Act
        await _trainingService.DeleteExercise(1, CancellationToken.None);

        // Assert
        var deletedExercise = await _context.Exercises.SingleOrDefaultAsync(e => e.Id == 1);
        Assert.Null(deletedExercise);
    }

    [Fact]
    public async Task DeleteTraining_RemovesTrainingFromDatabase()
    {
        // Arrange

        // Act
        await _trainingService.DeleteTraining(1, CancellationToken.None);
        await _context.SaveChangesAsync(true);

        // Assert
        var deletedTraining = await _context.Trainings.FindAsync(1);
        Assert.Null(deletedTraining);
    }

    [Fact]
    public async Task GetAllExercises_ReturnsAllExercises()
    {
        // Arrange

        // Act
        var result = await _trainingService.GetAllExercises(CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetAllTrainings_ReturnsAllTrainings()
    {
        // Arrange

        // Act
        var result = await _trainingService.GetAllTrainings(CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetExercise_ReturnsExercise()
    {
        // Arrange

        // Act
        var result = await _trainingService.GetExercise(1, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Push Up", result.Name);
    }

    [Fact]
    public async Task UpdateTraining_UpdatesTrainingInDatabase()
    {
        // Arrange
        var training = await _context.Trainings.AsNoTracking().SingleAsync(t => t.Id == 1);
        var updatedTrainingDTO = new TrainingDTO {Id=1, Name = "Updated Routine" };

        // Act
        await _trainingService.UpdateTraining(updatedTrainingDTO, CancellationToken.None);

        // Assert
        var updatedTraining = await _context.Trainings.AsNoTracking().SingleAsync(t => t.Id == 1);
        Assert.NotNull(updatedTraining);
        Assert.Equal("Updated Routine", updatedTraining.Name);
    }

    public async Task DisposeAsync()
    {
      //  await ResetDb();
        await _msSqlContainer.StopAsync();
    }

    private async Task ResetDb()
    {
        _context.TrainingSetsExercises.RemoveRange(_context.TrainingSetsExercises
            .Include(t => t.TrainingSets));
        _context.Exercises.RemoveRange(_context.Exercises);
        _context.Trainings.RemoveRange(_context.Trainings
            .Include(t => t.TrainingSetExercise));
        await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Exercises', RESEED, 0)");
        await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('TrainingSets', RESEED, 0)");
        await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Trainings', RESEED, 0)");
        await _context.SaveChangesAsync();
    }
}

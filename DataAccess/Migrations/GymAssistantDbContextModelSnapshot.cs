﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(GymAssistantDbContext))]
    partial class GymAssistantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MuscleGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DataAccess.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isLogged")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingSetExerciseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("TrainingSetExerciseId");

                    b.ToTable("TrainingSets");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSetExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TrainingSetsExercises");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingLog", b =>
                {
                    b.HasOne("DataAccess.Entities.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSet", b =>
                {
                    b.HasOne("DataAccess.Entities.TrainingSetExercise", null)
                        .WithMany("TrainingSets")
                        .HasForeignKey("TrainingSetExerciseId");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSetExercise", b =>
                {
                    b.HasOne("DataAccess.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Training", null)
                        .WithMany("TrainingSetExercise")
                        .HasForeignKey("TrainingId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("DataAccess.Entities.Training", b =>
                {
                    b.Navigation("TrainingSetExercise");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSetExercise", b =>
                {
                    b.Navigation("TrainingSets");
                });
#pragma warning restore 612, 618
        }
    }
}

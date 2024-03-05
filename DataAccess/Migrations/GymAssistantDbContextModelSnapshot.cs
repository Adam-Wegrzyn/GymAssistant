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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainingSessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingSessionId");

                    b.ToTable("TrainingLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingsPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingsPlanId");

                    b.ToTable("TrainingSessionss");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingSessionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasPrecision(1)
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("TrainingSessionId");

                    b.ToTable("TrainingSets");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingLog", b =>
                {
                    b.HasOne("DataAccess.Entities.TrainingSession", "TrainingSession")
                        .WithMany()
                        .HasForeignKey("TrainingSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingSession");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSession", b =>
                {
                    b.HasOne("DataAccess.Entities.TrainingPlan", "TrainingsPlan")
                        .WithMany("TrainingSessions")
                        .HasForeignKey("TrainingsPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingsPlan");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSet", b =>
                {
                    b.HasOne("DataAccess.Entities.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.TrainingSession", "TrainingSession")
                        .WithMany("TrainingSets")
                        .HasForeignKey("TrainingSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("TrainingSession");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingPlan", b =>
                {
                    b.Navigation("TrainingSessions");
                });

            modelBuilder.Entity("DataAccess.Entities.TrainingSession", b =>
                {
                    b.Navigation("TrainingSets");
                });
#pragma warning restore 612, 618
        }
    }
}

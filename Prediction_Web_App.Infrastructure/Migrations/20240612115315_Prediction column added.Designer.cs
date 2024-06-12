﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prediction_Web_App.Infrastructure.Data;

#nullable disable

namespace Prediction_Web_App.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240612115315_Prediction column added")]
    partial class Predictioncolumnadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Country", b =>
                {
                    b.Property<int>("Country_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Country_ID"), 1L, 1);

                    b.Property<string>("Country_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlagWebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Country_ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Fixture", b =>
                {
                    b.Property<int>("Fixture_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Fixture_ID"), 1L, 1);

                    b.Property<string>("Country1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country1_Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Country1_Score")
                        .HasColumnType("int");

                    b.Property<string>("Country2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country2_Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Country2_Score")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Fixture_ID");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Goal_Scorer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Fixture_Id")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Fixture_Id");

                    b.HasIndex("Player_Id");

                    b.ToTable("Goal_Scorers");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Player_Info", b =>
                {
                    b.Property<int>("Player_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Player_ID"), 1L, 1);

                    b.Property<int>("Country_Id")
                        .HasColumnType("int");

                    b.Property<string>("Player_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Player_ID");

                    b.HasIndex("Country_Id");

                    b.ToTable("Player_Infos");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Prediction", b =>
                {
                    b.Property<int>("Prediction_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Prediction_ID"), 1L, 1);

                    b.Property<int>("Country1_Score")
                        .HasColumnType("int");

                    b.Property<int>("Country2_Score")
                        .HasColumnType("int");

                    b.Property<int>("Fixture_ID")
                        .HasColumnType("int");

                    b.Property<string>("Goal_Scorer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Prediction_ID");

                    b.HasIndex("Fixture_ID");

                    b.ToTable("Predictions");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Scorecard", b =>
                {
                    b.Property<int>("Final_Score_Points")
                        .HasColumnType("int");

                    b.Property<int>("Fixture_ID")
                        .HasColumnType("int");

                    b.Property<int>("Goal_Scorer_Points")
                        .HasColumnType("int");

                    b.Property<int>("Result_Points")
                        .HasColumnType("int");

                    b.Property<int>("Total_Points")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.ToTable("Scorecards");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Goal_Scorer", b =>
                {
                    b.HasOne("Prediction_Web_App.Core.Entities.Fixture", "Fixture")
                        .WithMany("Goal_Scorers")
                        .HasForeignKey("Fixture_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prediction_Web_App.Core.Entities.Player_Info", "Player")
                        .WithMany("GoalScorers")
                        .HasForeignKey("Player_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fixture");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Player_Info", b =>
                {
                    b.HasOne("Prediction_Web_App.Core.Entities.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Prediction", b =>
                {
                    b.HasOne("Prediction_Web_App.Core.Entities.Fixture", "Fixture")
                        .WithMany("Predictions")
                        .HasForeignKey("Fixture_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fixture");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Country", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Fixture", b =>
                {
                    b.Navigation("Goal_Scorers");

                    b.Navigation("Predictions");
                });

            modelBuilder.Entity("Prediction_Web_App.Core.Entities.Player_Info", b =>
                {
                    b.Navigation("GoalScorers");
                });
#pragma warning restore 612, 618
        }
    }
}

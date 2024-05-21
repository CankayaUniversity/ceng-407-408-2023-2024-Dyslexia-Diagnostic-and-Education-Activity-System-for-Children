﻿// <auto-generated />
using System;
using DyslexiaApp.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DyslexiaApp.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.DyslexiaDiagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("FeedBack")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TestResults")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DyslexiaDiagnosis", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.EducationalGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EducationalGames", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.GameSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationalGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MatchingGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NavigationGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SessionScore")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EducationalGameId");

                    b.HasIndex("MatchingGameId");

                    b.HasIndex("NavigationGameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameSessions", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.MatchingGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DyslexiaDiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EducationalGameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DyslexiaDiagnosisId");

                    b.HasIndex("EducationalGameId");

                    b.ToTable("MatchingGames", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.NavigationGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BalloonPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DyslexiaDiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DyslexiaDiagnosisId");

                    b.ToTable("NavigationGames", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.NavigationGameQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BaloonPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NavigationGameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NavigationGameId");

                    b.ToTable("NavigationGameQuestions", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CorrectAnswerIndex")
                        .HasColumnType("int");

                    b.Property<Guid?>("MainImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MatchingGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainImageId");

                    b.HasIndex("MatchingGameId");

                    b.ToTable("Questions", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Sistem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Layout")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NavigationElements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sistems", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Support", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactString")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FAQs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SistemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SupportStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("SistemId");

                    b.ToTable("Supports", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProfileUpdateToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProfileUpdateTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetPasswordTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.DyslexiaDiagnosis", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.User", "User")
                        .WithMany("DyslexiaDiagnoses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.EducationalGame", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.User", "User")
                        .WithMany("EducationalGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.GameSession", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.EducationalGame", "EducationalGame")
                        .WithMany("GameSessions")
                        .HasForeignKey("EducationalGameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DyslexiaApp.API.Data.Entities.MatchingGame", null)
                        .WithMany("GameSessions")
                        .HasForeignKey("MatchingGameId");

                    b.HasOne("DyslexiaApp.API.Data.Entities.NavigationGame", null)
                        .WithMany("GameSessions")
                        .HasForeignKey("NavigationGameId");

                    b.HasOne("DyslexiaApp.API.Data.Entities.User", "User")
                        .WithMany("GameSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EducationalGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Image", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.Question", null)
                        .WithMany("ImageOptions")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.MatchingGame", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.DyslexiaDiagnosis", "DyslexiaDiagnosis")
                        .WithMany("MatchingGames")
                        .HasForeignKey("DyslexiaDiagnosisId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DyslexiaApp.API.Data.Entities.EducationalGame", "EducationalGame")
                        .WithMany("MatchingGames")
                        .HasForeignKey("EducationalGameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DyslexiaDiagnosis");

                    b.Navigation("EducationalGame");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.NavigationGame", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.DyslexiaDiagnosis", "DyslexiaDiagnosis")
                        .WithMany("NavigationGames")
                        .HasForeignKey("DyslexiaDiagnosisId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DyslexiaDiagnosis");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.NavigationGameQuestion", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.NavigationGame", null)
                        .WithMany("Questions")
                        .HasForeignKey("NavigationGameId");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Question", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");

                    b.HasOne("DyslexiaApp.API.Data.Entities.MatchingGame", null)
                        .WithMany("Questions")
                        .HasForeignKey("MatchingGameId");

                    b.Navigation("MainImage");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Sistem", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.User", "User")
                        .WithMany("Sistems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Support", b =>
                {
                    b.HasOne("DyslexiaApp.API.Data.Entities.Sistem", "Sistem")
                        .WithMany("Supports")
                        .HasForeignKey("SistemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Sistem");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.DyslexiaDiagnosis", b =>
                {
                    b.Navigation("MatchingGames");

                    b.Navigation("NavigationGames");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.EducationalGame", b =>
                {
                    b.Navigation("GameSessions");

                    b.Navigation("MatchingGames");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.MatchingGame", b =>
                {
                    b.Navigation("GameSessions");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.NavigationGame", b =>
                {
                    b.Navigation("GameSessions");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Question", b =>
                {
                    b.Navigation("ImageOptions");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.Sistem", b =>
                {
                    b.Navigation("Supports");
                });

            modelBuilder.Entity("DyslexiaApp.API.Data.Entities.User", b =>
                {
                    b.Navigation("DyslexiaDiagnoses");

                    b.Navigation("EducationalGames");

                    b.Navigation("GameSessions");

                    b.Navigation("Sistems");
                });
#pragma warning restore 612, 618
        }
    }
}

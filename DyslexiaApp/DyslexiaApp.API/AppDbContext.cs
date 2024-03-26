using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DyslexiaApp.API
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // Users tablosu için bir DbSet
        public DbSet<Sistem> Sistems { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<NavigationGame> NavigationGames { get; set; }
        public DbSet<MatchingGame> MatchingGames { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<EducationalGame> EducationalGames { get; set; }
        public DbSet<DyslexiaDiagnosis> DyslexiaDiagnosis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ile EducationalGames arasındaki ilişki
            modelBuilder.Entity<EducationalGame>()
                .HasOne(eg => eg.User)
                .WithMany(u => u.EducationalGames)
                
                .OnDelete(DeleteBehavior.NoAction);

            // User ile DyslexiaDiagnosis arasındaki ilişki
            modelBuilder.Entity<DyslexiaDiagnosis>()
                .HasOne(dd => dd.User)
                .WithMany(u => u.DyslexiaDiagnoses)
               
                .OnDelete(DeleteBehavior.NoAction);

            // DyslexiaDiagnosis ile NavigationGame arasındaki ilişki
            modelBuilder.Entity<NavigationGame>()
                .HasOne(ng => ng.DyslexiaDiagnosis)
                .WithMany(dd => dd.NavigationGames)
              
                .OnDelete(DeleteBehavior.NoAction);

            // DyslexiaDiagnosis ile MatchingGame arasındaki ilişki
            modelBuilder.Entity<MatchingGame>()
                .HasOne(mg => mg.DyslexiaDiagnosis)
                .WithMany(dd => dd.MatchingGames)
               
                .OnDelete(DeleteBehavior.NoAction);

            // EducationalGame ile MatchingGame arasındaki ilişki
            modelBuilder.Entity<MatchingGame>()
                .HasOne(mg => mg.EducationalGame)
                .WithMany(eg => eg.MatchingGames)
         
                .OnDelete(DeleteBehavior.NoAction);

            // User ile Sistem arasındaki ilişki
            modelBuilder.Entity<Sistem>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sistems)
               
                .OnDelete(DeleteBehavior.NoAction);

            // Sistem ile Support arasındaki ilişki
            modelBuilder.Entity<Support>()
                .HasOne(su => su.Sistem)
                .WithMany(s => s.Supports)
              
                .OnDelete(DeleteBehavior.NoAction);

            // User ile GameSession arasındaki ilişki
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.User)
                .WithMany(u => u.GameSessions)
                
                .OnDelete(DeleteBehavior.NoAction);

            // EducationalGame ile GameSession arasındaki ilişki
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.EducationalGame)
                .WithMany(eg => eg.GameSessions)
              
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

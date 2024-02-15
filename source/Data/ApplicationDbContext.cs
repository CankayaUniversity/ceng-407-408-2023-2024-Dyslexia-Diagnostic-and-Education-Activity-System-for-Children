using Duende.IdentityServer.EntityFramework.Options;
using DyslexiaEduGameApp.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DyslexiaEduGameApp.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Sistem> Sistems { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<NavigationGame> NavigationGames { get; set; }
        public DbSet<MatchingGame> MatchingGames { get; set; }
        public DbSet<GameSession> GameSessions{ get; set; }
        public DbSet<EducationalGame> EducationalGames { get; set; }
        public DbSet<DyslexiaDiagnosis> DyslexiaDiagnosis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // GameSession ve MatchingGame arasındaki bir-çok ilişkiyi yapılandırın
            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.MatchingGames) // GameSession sınıfındaki navigasyon özelliği
                .WithMany(mg => mg.GameSessions) // MatchingGame sınıfındaki koleksiyon
                .HasForeignKey(gs => gs.MatchingGameId) // GameSession sınıfındaki yabancı anahtar
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.NavigationGames)
                .WithMany(ng => ng.GameSessions)
                .HasForeignKey(gs => gs.NavigationGameId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MatchingGame>()
                 .HasOne(mg => mg.EducationalGames)
                 .WithMany(eg => eg.MatchingGames)
                 .HasForeignKey(mg => mg.EducationalGameId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NavigationGame>()
                 .HasOne(ng => ng.EducationalGames)
                 .WithMany(eg => eg.NavigationGames)
                 .HasForeignKey(ng => ng.EducationalGameId)
                 .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EducationalGame>()
                 .HasMany(e => e.GameSessions)
                 .WithMany(g => g.EducationalGames)
                 .UsingEntity<Dictionary<string, object>>(
                    "EducationalGameGameSession",
                 j => j.HasOne<GameSession>().WithMany().OnDelete(DeleteBehavior.NoAction),
                 j => j.HasOne<EducationalGame>().WithMany().OnDelete(DeleteBehavior.NoAction)
        );





        }
    }
}
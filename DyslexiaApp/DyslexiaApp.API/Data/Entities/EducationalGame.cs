using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class EducationalGame
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; } // Oyunun açıklaması. Oyun hakkında genel bilgiler içerir.

        public virtual User User { get; set; }

        // Her eğitim oyununun birden fazla oyun oturumu olabilir.
        public virtual List<GameSession> GameSessions { get; set; }
        public virtual List<MatchingGame> MatchingGames { get; set; }

        // Eğitici oyun oluşturulduğunda GameSessions listesini başlatmak için constructor.
        public EducationalGame()
        {
            GameSessions = new List<GameSession>();
            MatchingGames = new List<MatchingGame>();
        }

    }
}

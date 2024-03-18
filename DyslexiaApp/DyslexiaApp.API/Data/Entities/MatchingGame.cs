using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class MatchingGame 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public TimeSpan TimeSpent { get; set; }

       
        public virtual DyslexiaDiagnosis DyslexiaDiagnosis { get; set; }

       
        public virtual EducationalGame EducationalGame { get; set; }

        // Her MatchingGame, birden fazla GameSession ile ilişkilendirilebilir.
        public virtual ICollection<GameSession> GameSessions { get; set; }

        public MatchingGame()
        {
            // GameSessions koleksiyonunu başlatmak.
            GameSessions = new HashSet<GameSession>();
        }
    }
}

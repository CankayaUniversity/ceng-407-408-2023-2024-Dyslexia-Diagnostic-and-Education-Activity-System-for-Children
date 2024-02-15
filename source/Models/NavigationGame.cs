using DyslexiaEduGameApp.Models.Entities;

namespace DyslexiaEduGameApp.Models
{
    public class NavigationGame : BaseEntity
    {
        public Guid GameId { get; set; }
        public Guid DiagnosisId { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public int GameSessionId { get; set; }
        public int EducationalGameId { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }
        public virtual DyslexiaDiagnosis DyslexiaDiagnosis { get; set; }
        public virtual EducationalGame EducationalGames { get; set; }
    }
}

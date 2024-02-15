using DyslexiaEduGameApp.Models.Entities;

namespace DyslexiaEduGameApp.Models
{
    public class GameSession : BaseEntity
    {
        
        public TimeSpan TimeSpent { get; set; }
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public int MatchingGameId { get;  set; }
        public int NavigationGameId { get;  set; }
        public int EducationalGameId { get; set; }

        public virtual ICollection<EducationalGame> EducationalGames  { get; set; }
        public virtual MatchingGame MatchingGames { get; set; }
        public virtual NavigationGame NavigationGames { get; set; }
        public virtual ApplicationUser Users { get; set; }
        
    }
}

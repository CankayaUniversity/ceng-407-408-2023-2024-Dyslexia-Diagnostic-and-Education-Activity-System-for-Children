using DyslexiaEduGameApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DyslexiaEduGameApp.Models
{
    public class EducationalGame : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int MatchingGameId { get; set; }
        public int GameSessionId { get; set; }
        public int NavigationGameId { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }
        public virtual ICollection<MatchingGame> MatchingGames { get; set; }
        public virtual ICollection<NavigationGame> NavigationGames { get; set; }
       
    }
}

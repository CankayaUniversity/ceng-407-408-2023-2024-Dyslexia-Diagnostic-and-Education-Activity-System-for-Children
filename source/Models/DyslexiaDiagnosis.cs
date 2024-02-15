using DyslexiaEduGameApp.Models.Entities;

namespace DyslexiaEduGameApp.Models
{
    public class DyslexiaDiagnosis : BaseEntity
    {
        public Guid UserId { get; set; }
        public int TestResults { get; set; }
        public string FeedBack { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser Users { get; set; }
        public virtual ICollection<MatchingGame> MatchingGames { get; set; }
        public virtual ICollection<NavigationGame> NavigationGames { get; set; }
    }
}

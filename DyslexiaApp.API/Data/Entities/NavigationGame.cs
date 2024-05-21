using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class NavigationGame 
    {
        // Bu sınıf, oyun ID'leri, tanı ID'leri, oyun süresi ve oturum bilgilerini içerir.

        [Key]
        public Guid Id { get; set; }

        // Oyunun oynanma süresi.
        public string BalloonPosition { get; set; }  // 'Right' veya 'Left'

        public virtual ICollection<GameSession> GameSessions { get; set; }
        public virtual DyslexiaDiagnosis DyslexiaDiagnosis { get; set; }
        public virtual ICollection<NavigationGameQuestion> Questions { get; set; }
        public NavigationGame()
        {
            GameSessions = new HashSet<GameSession>();
            Questions = new HashSet<NavigationGameQuestion>();
        }

    }
}

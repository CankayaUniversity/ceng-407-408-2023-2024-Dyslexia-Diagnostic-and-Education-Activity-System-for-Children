using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class GameSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public TimeSpan TimeSpent { get; set; }

        // Her oyun oturumu bir kullanıcıya ait olacaktır.
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        // Her oyun oturumu yalnızca bir oyun türüne ait olacaktır.
        // Bu ForeignKey, EducationalGame, MatchingGame veya NavigationGame olabilir.
        // İlişkili oyun türünün ne olduğunu anlamak için Game türünde bir navigation property kullanılır.
        [ForeignKey("EducationalGame")]
        public Guid EducationalGameId { get; set; }
        public virtual EducationalGame EducationalGame { get; set; }

        // Oyun oturumuna özgü skor veya diğer özellikler eklenebilir.
        public int SessionScore { get; set; }

        // Her oyun oturumu için kayıt metodları veya diğer işlemler yapılabilir.
        public void RecordSession()
        {
            // Oyun oturumunu kaydetme işlemleri
        }
    }
}

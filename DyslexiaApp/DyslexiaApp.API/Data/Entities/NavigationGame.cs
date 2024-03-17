using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class NavigationGame 
    {
        // Bu sınıf, oyun ID'leri, tanı ID'leri, oyun süresi ve oturum bilgilerini içerir.

        [Key]
        public Guid Id { get; set; }

        [Required]
        public TimeSpan TimeSpent { get; set; } // Oyunun oynanma süresi.

        [ForeignKey("DyslexiaDiagnosis")]
        public Guid DyslexiaDiagnosisId { get; set; }
        public virtual DyslexiaDiagnosis DyslexiaDiagnosis { get; set; }

    }
}

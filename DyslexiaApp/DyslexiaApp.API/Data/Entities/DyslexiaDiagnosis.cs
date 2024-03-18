using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    public class DyslexiaDiagnosis
    {
        [Key]
        public Guid Id { get; set; }

       
        public virtual User User { get; set; }

        [Required]
        public int TestResults { get; set; } // Kullanıcının disleksi testinden aldığı sonuçların sayısal ifadesi.

        [StringLength(1000)]
        public string FeedBack { get; set; } // Kullanıcıya yönelik genel geri bildirim.

        [StringLength(2000)]
        public string Description { get; set; } // Tanıyla ilgili ek açıklamalar.

        public virtual List<MatchingGame> MatchingGames { get; set; }
        public virtual List<NavigationGame> NavigationGames { get; set; }

        public DyslexiaDiagnosis() 
        {
            MatchingGames = new List<MatchingGame>();
            NavigationGames = new List<NavigationGame>();
        }
    }
}

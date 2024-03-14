using DyslexiaApp.API.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DyslexiaApp.API.Data.Entities
{
    public class User
    {
        [Key] 
        public Guid Id { get; set; }

        [Required] 
        [MaxLength(30)] 
        public string FirstName { get; set; }

        [Required] 
        [MaxLength(30)]
        public string LastName { get; set; }

        
        public DateTime Birthday { get; set; } 

        [Range(minimum:0, maximum:100)] //belirli bir aralık tanımlamak için
        public int Accuracy { get; set; }

        [Required] 
        [MaxLength(50)]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required] 
        public Role Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual List<EducationalGame> EducationalGames { get; set; }
        public virtual List<DyslexiaDiagnosis> DyslexiaDiagnoses { get; set; }
        public virtual List<Sistem> Sistems { get; set; }
        public virtual ICollection<GameSession> GameSessions { get; set; }

        // Kullanıcı oluşturulduğunda GameSessions ve DyslexiaDiagnoses listelerini başlatmak için constructor.
        public User()
        {
            EducationalGames = new List<EducationalGame>();
            DyslexiaDiagnoses = new List<DyslexiaDiagnosis>();
            Sistems = new List<Sistem>();
            GameSessions = new HashSet<GameSession>();
        }

        // Kullanıcı ile ilgili diğer metodlar, örneğin hesap oluşturma, profil güncelleme vs. burada tanımlanabilir.

    }
}

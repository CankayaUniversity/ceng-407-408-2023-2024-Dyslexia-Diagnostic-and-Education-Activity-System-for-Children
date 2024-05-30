using DyslexiaAppMAUI.Shared.Dtos;
using DyslexiaAppMAUI.Shared.Models;
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

        [Required]
        public DateTime Birthday { get; set; } 

        [Range(minimum:0, maximum:100)] //belirli bir aralık tanımlamak için
        public int Accuracy { get; set; }

        [Required] 
        [MaxLength(50)]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public string Salt { get; set; }


        [Required] 
        public Role Role { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }

        public string? VerificationCode { get; set; }
        public DateTime? VerificationCodeExpiry { get; set; }



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

        public void UpdateProfile(string firstName, string lastName, string email, DateTime birthday, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Birthday = birthday;
            Gender = gender;
        }
        public LoggedInUser ToLoggedInUser()
        {
            return new LoggedInUser(Id, FirstName, LastName, Email, Birthday, Gender,Accuracy);
        }

        // Kullanıcı ile ilgili diğer metodlar, örneğin hesap oluşturma, profil güncelleme vs. burada tanımlanabilir.

    }
}

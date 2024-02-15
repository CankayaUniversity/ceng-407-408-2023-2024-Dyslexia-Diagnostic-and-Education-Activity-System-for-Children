using DyslexiaEduGameApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using static DyslexiaEduGameApp.Models.Enum.Enum;
using System.ComponentModel.DataAnnotations;

namespace DyslexiaEduGameApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthay { get; set; }
        public Gender Gender { get; set; }
        public DyslexiaStatus Status { get; set; }
        public Role Role { get; set; }
        public int Accuracy { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public virtual ICollection<DyslexiaDiagnosis> DyslexiaDiagnosis { get; set; }
        public virtual EducationalGame EducationalGames { get; set; }
        public virtual Sistem Sistems { get; set; }

    }
}
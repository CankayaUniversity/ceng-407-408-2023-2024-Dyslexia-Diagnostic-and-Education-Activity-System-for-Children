using DyslexiaEduGameApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DyslexiaEduGameApp.Models
{
    public class Sistem : BaseEntity
    {

        public string Layout { get; set; }
        public TimeSpan TimeSpent { get; set; }

        public string NavigationElements { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual Support Supports { get; set; }
    }
}

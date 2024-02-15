using DyslexiaEduGameApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DyslexiaEduGameApp.Models
{
    public class Support : BaseEntity
    {
        public TimeSpan TimeSpent { get; set; }
        public string FAQs { get; set; }
        public string ContactString { get; set; }
        public string Message { get; set; }
        public string SupportStatus { get; set; }
        public virtual ICollection<Sistem> Sistems { get; set; }
    }
}

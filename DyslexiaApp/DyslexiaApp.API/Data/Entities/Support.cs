using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    // Destek taleplerini saklamak için kullanılan sınıf.
    public class Support  
    {
        [Key]
        public Guid Id { get; set; } 

        public TimeSpan TimeSpent { get; set; } // Kullanıcının sorununu çözmek için harcanan zaman.

        public string FAQs { get; set; } // Kullanıcıların sorularına hızlı cevap bulmalarını sağlamak amacıyla kullanılır.

        [Required]
        [StringLength(255)]
        public string ContactString { get; set; } // Telefon numarası, e-posta adresi gibi iletişim bilgileri bu string içinde saklanabilir.

        [Required]
        public string Message { get; set; } // Kullanıcının destek ekibine iletmek istediği mesaj.

        [Required]
        [StringLength(50)]
        public string SupportStatus { get; set; } // Destek talebinin mevcut durumunu gösterir. Örneğin: "Açık", "Cevaplandı", "Kapalı".

        
        public virtual Sistem Sistem { get; set; }

    }
}

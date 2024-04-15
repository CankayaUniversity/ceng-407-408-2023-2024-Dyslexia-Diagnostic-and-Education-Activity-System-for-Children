using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DyslexiaApp.API.Data.Entities
{
    // Uygulamanın sistem yapılandırmasını saklamak için kullanılan sınıf.
    public class Sistem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Layout { get; set; } // Bu alanın içeriği, uygulamanın kullanıcı arayüzü düzeninin nasıl olduğunu açıklar.

        //[Required]
        //public TimeSpan TimeSpent { get; set; } // Kullanıcıların sistemle etkileşimde geçirdiği toplam zaman.

        [Required]
        public string NavigationElements { get; set; }  // Bu bilgi, kullanıcıların sistem içerisinde nasıl gezindiklerine dair önemli ipuçları sunar.

        public List<Support>Supports { get; set; } = new List<Support>();

        
        public virtual User User { get; set; }

        public Sistem()
        {
            Support supports = new Support();
        }
     }
}

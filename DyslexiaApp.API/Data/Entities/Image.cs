using System.ComponentModel.DataAnnotations;

namespace DyslexiaApp.API.Data.Entities
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public string Url {  get; set; }
        public string Description { get; set; }

    }
}

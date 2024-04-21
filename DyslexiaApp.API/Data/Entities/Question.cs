using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace DyslexiaApp.API.Data.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public Guid? MainImageId { get; set; }  // Yapıyı nullable yapmak için Guid? olarak değiştirin
        public virtual Image MainImage { get; set; }
        public virtual List<Image> ImageOptions { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}

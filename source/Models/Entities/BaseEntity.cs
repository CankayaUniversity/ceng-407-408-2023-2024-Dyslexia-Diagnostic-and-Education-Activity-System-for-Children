namespace DyslexiaEduGameApp.Models.Entities
{
    public class BaseEntity
    {

        public virtual int Id { get; set; }

        public virtual string? CreatedBy { get; set; }

        public virtual string? UpdatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public virtual DateTime? UpdatedDate { get; set; }
        
        public virtual bool IsActive { get; set; }
    }
}

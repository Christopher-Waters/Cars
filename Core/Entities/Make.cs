using System.ComponentModel.DataAnnotations;


namespace Core.Entities
{
    public class Make : BaseEntity
    {
        [Required]
        [StringLength(30, ErrorMessage = "The Make value cannot exceed 30 characters. ")] 
        public string Name { get; set; }
        public ICollection<ModelYear> ModelYears { get; set; }

    }
}
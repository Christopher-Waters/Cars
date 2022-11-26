using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [Index(nameof(Name), nameof(Year),nameof(MakeId), IsUnique = true)]
    public class ModelYear : BaseEntity
    {
        [Required]
        [StringLength(30, ErrorMessage = "The Model Name value cannot exceed 30 characters. ")] 
        public string Name { get; set; }

        [Required]
        [Range(4,4, ErrorMessage = "The Year value must 4 characters. ")] 
        public int Year { get; set; }

        public int MakeId { get; set; }
        public Make Makes { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using ControleDeGastosAPI.Enums;

namespace ControleDeGastosAPI.DTOs.CategoryDTO
{
    public abstract class CategoryBaseDTO
    {
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(400, ErrorMessage = "Description cannot exceed 400 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purpose is required")]
        public CategoryEnums Purpose { get; set; }
    }
}

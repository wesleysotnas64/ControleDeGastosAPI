using System.ComponentModel.DataAnnotations;

namespace ControleDeGastosAPI.DTOs.PersonDTO;

public abstract class PersonBaseDTO
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
    public int Age { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace ControleDeGastosAPI.DTOs.PersonDTO;

public abstract class PersonBaseDTO
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MaxLength(200, ErrorMessage = "Nome não pode exceder 200 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 150, ErrorMessage = "Idade deve estar entre 0 e 150.")]
    public int Age { get; set; }
}

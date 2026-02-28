using System.ComponentModel.DataAnnotations;
using ControleDeGastosAPI.Enums;

namespace ControleDeGastosAPI.DTOs.CategoryDTO;

public abstract class CategoryBaseDTO
{
    [Required(ErrorMessage = "Descrição é obrigatória.")]
    [MaxLength(400, ErrorMessage = "Descrição não pode exceder 400 caracteres.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Finalidade é obrigatória.")]
    public CategoryEnums Purpose { get; set; }
}

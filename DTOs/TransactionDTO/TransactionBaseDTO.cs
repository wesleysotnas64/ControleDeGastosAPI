using ControleDeGastosAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeGastosAPI.DTOs.TransactionDTO;

public abstract class TransactionBaseDTO
{
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [MaxLength(400)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Value { get; set; }

    [Required]
    public CategoryEnums Type { get; set; }

    [Required(ErrorMessage = "O ID da pessoa é obrigatório")]
    public Guid PersonId { get; set; }

    [Required(ErrorMessage = "O ID da categoria é obrigatório")]
    public Guid CategoryId { get; set; }
}

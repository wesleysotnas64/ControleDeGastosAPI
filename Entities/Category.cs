using ControleDeGastosAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastosAPI.Entities;

public class Category
{
    // Para o banco identificar cada categoria de forma única.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    // O nome da categoria é obrigatório e tem um limite de 400 caracteres.
    [Required]
    [MaxLength(400)]
    public string? Description { get; set; }
    [Required]
    public CategoryEnums Purpose { get; set; }
}

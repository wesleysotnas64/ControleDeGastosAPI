using System.ComponentModel.DataAnnotations;
using ControleDeGastosAPI.Enums;

namespace ControleDeGastosAPI.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(400)]
    public string? Description { get; set; }
    [Required]
    public CategoryEnums Purpose { get; set; }
}

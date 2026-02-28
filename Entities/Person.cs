using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastosAPI.Entities;

public class Person
{
    // Para o banco identificar cada pessoa de forma única.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    // O nome da pessoa é obrigatório e tem um limite de 200 caracteres.
    [Required]
    [MaxLength(200)]
    public string? Name { get; set; }

    [Required]
    public int Age { get; set; }
}

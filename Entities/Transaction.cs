using ControleDeGastosAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastosAPI.Entities;

public class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(400)]
    public string? Description { get; set; }

    [Required]
    public decimal Value { get; set; }

    [Required]
    public CategoryEnums Type { get; set; }

    [Required]
    public Guid PersonId { get; set; }
    [ForeignKey("PersonId")] // Avisa ao banco que este campo aponta para a tabela People
    public Person? Person { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")] // Avisa ao banco que este campo aponta para a tabela Categories
    public Category? Category { get; set; }

}

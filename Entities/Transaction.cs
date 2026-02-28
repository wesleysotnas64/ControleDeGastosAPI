using ControleDeGastosAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeGastosAPI.Entities;

public class Transaction
{

    // Para o banco identificar cada transação de forma única.
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    // A descrição da transação é obrigatória e tem um limite de 400 caracteres.
    [Required]
    [MaxLength(400)]
    public string? Description { get; set; }

    // Valor é obrigatório.
    [Required]
    public decimal Value { get; set; }

    [Required]
    public CategoryEnums Type { get; set; }

    [Required]
    public Guid PersonId { get; set; }
    [ForeignKey("PersonId")] // Avisa ao banco que este campo aponta para a tabela People FK
    public Person? Person { get; set; } // Necessário para o Entity Framework entender a relação entre as tabelas, mas não é obrigatório para a lógica do sistema.

    [Required]
    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")] // Avisa ao banco que este campo aponta para a tabela Categories FK
    public Category? Category { get; set; } // Necessário para o Entity Framework entender a relação entre as tabelas, mas não é obrigatório para a lógica do sistema.

}

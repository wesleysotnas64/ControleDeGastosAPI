namespace ControleDeGastosAPI.DTOs.TransactionDTO;

public class TransactionResponseDTO : TransactionBaseDTO
{
    public Guid Id { get; set; }
    public string? PersonName { get; set; }
    public string? CategoryDescription { get; set; }
}

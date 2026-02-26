using ControleDeGastosAPI.DTOs.PersonDTO;

namespace ControleDeGastosAPI.DTOs.DashboardDTO;

public class DashboardPersonTotalDTO
{
    public PersonResponseDTO Person { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}

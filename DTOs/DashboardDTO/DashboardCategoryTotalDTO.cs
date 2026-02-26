using ControleDeGastosAPI.DTOs.CategoryDTO;

namespace ControleDeGastosAPI.DTOs.DashboardDTO;

public class DashboardCategoryTotalDTO
{
    public CategoryResponseDTO Category { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}

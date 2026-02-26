namespace ControleDeGastosAPI.DTOs.DashboardDTO;

public class DashboardCategorySummaryDTO
{
    public List<DashboardCategoryTotalDTO> CategoryTotals { get; set; }
    public decimal GrandTotalIncome { get; set; }
    public decimal GrandTotalExpense { get; set; }
    public decimal GrandBalance { get; set; }
}

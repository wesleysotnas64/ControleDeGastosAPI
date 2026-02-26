namespace ControleDeGastosAPI.DTOs.DashboardDTO;

public class DashboardPeopleSummaryDTO
{
    public List<DashboardPersonTotalDTO> PeopleTotals { get; set; }
    public decimal GrandTotalIncome { get; set; }
    public decimal GrandTotalExpense { get; set; }
    public decimal GrandBalance { get; set; }
}

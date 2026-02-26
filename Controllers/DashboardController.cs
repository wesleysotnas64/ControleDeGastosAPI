using ControleDeGastosAPI.DTOs.DashboardDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("dashboard")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("totals-by-person")]
    public async Task<ActionResult<DashboardPeopleSummaryDTO>> TotalsByPerson()
    {
        try
        {
            var result = await _dashboardService.GetPeopleSummaryAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno ao processar o dashboard: {ex.Message}");
        }
    }
}

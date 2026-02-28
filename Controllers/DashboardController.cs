using ControleDeGastosAPI.DTOs.DashboardDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("dashboard")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    // Injeção de dependência do serviço de dashboard
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
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpGet("totals-by-category")]
    public async Task<ActionResult<DashboardCategorySummaryDTO>> TotalsByCategory()
    {
        try
        {
            var result = await _dashboardService.GetCategorySummaryAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }
}

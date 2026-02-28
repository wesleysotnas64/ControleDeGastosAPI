using ControleDeGastosAPI.DTOs.TransactionDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("transaction")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    // Injeção de dependência do serviço de transação
    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<TransactionResponseDTO>> Create([FromBody] TransactionCreateDTO transactionCreateDTO)
    {
        try
        {
            var result = await _transactionService.CreateTransactionAsync(transactionCreateDTO);
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<TransactionResponseDTO>>> GetAll()
    {
        try
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

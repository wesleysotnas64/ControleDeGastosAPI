using ControleDeGastosAPI.DTOs.CategoryDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    // Injeção de dependência do serviço de categoria
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CategoryResponseDTO>> Create([FromBody] CategoryCreateDTO categoryCreateDTO)
    {
        try
        {
            var result = await _categoryService.CreateCategoryAsync(categoryCreateDTO);
            return CreatedAtAction(nameof(Create), new {id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<CategoryResponseDTO>>> GetAll()
    {
        try
        {
            var result = await _categoryService.GetAllCategoryAsync();
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

using ControleDeGastosAPI.DTOs.CategoryDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CategoryResponseDTO>> Create([FromBody] CategoryCreateDTO categoryCreateDTO)
    {
        var result = await _categoryService.CreateCategoryAsync(categoryCreateDTO);

        return CreatedAtAction(nameof(Create), new {id = result.Id }, result);
    }
}

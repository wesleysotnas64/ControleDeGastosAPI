using ControleDeGastosAPI.DTOs.PersonDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    // Injeção de dependência do serviço de pessoa
    public PersonController(PersonService personService)
    {
        _personService = personService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<PersonResponseDTO>> Create([FromBody] PersonCreateDTO personCreateDTO)
    {
        try
        {
            var result = await _personService.CreatePersonAsync(personCreateDTO);
            return CreatedAtAction(nameof(Create), new {id = result.Id}, result);

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<PersonResponseDTO>>> GetAll()
    {
        try
        {
            var result = await _personService.GetAllPeopleAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<PersonResponseDTO>> Update(Guid id, [FromBody] PersonUpdateDTO personUpdateDTO)
    {
        try
        {
            var result = await _personService.UpdatePersonAsync(id, personUpdateDTO);

            if (result == null)
            {
                return NotFound(new {message = "Pessoa não encontrada."});
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _personService.DeletePersonAsync(id);

            if (!result)
            {
                return NotFound(new {message = "Pessoa não encontrada."});
            }

            return NoContent();
        } 
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

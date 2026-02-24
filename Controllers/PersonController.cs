using ControleDeGastosAPI.DTOs.PersonDTO;
using ControleDeGastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastosAPI.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;
    public PersonController(PersonService personService)
    {
        _personService = personService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<PersonResponseDTO>> Create([FromBody] PersonCreateDTO personCreateDTO)
    {
        var result = await _personService.CreatePersonAsync(personCreateDTO);

        return CreatedAtAction(nameof(Create), new {id = result.Id}, result);
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<PersonResponseDTO>>> GetAll()
    {
        var result = await _personService.GetAllPeopleAsync();
        return Ok(result);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<PersonResponseDTO>> Update(Guid id, [FromBody] PersonUpdateDTO personUpdateDTO)
    {
        var result = await _personService.UpdatePersonAsync(id, personUpdateDTO);

        if (result == null)
        {
            return NotFound(new {mwssage = "Pessoa não encontrada."});
        }

        return Ok(result);
    }
}

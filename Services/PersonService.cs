using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.PersonDTO;
using ControleDeGastosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastosAPI.Services;

public class PersonService
{
    private readonly ContextAPI _context;

    public PersonService(ContextAPI context)
    {
        _context = context;
    }

    public async Task<PersonResponseDTO> CreatePersonAsync(PersonCreateDTO personCreateDTO)
    {
        var person = new Person
        {
            Name = personCreateDTO.Name,
            Age = personCreateDTO.Age
        };

        _context.People.Add(person);
        await _context.SaveChangesAsync();

        return new PersonResponseDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
        };
    }

    public async Task<List<PersonResponseDTO>> GetAllPeopleAsync()
    {
        var people = await _context.People.ToListAsync();
        return people.Select(p => new PersonResponseDTO
        {
            Id = p.Id,
            Name = p.Name,
            Age = p.Age
        }).ToList();
    }

    public async Task<PersonResponseDTO?> UpdatePersonAsync(Guid id, PersonUpdateDTO personUpdateDTO)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null) return null;

        person.Name = personUpdateDTO.Name;
        person.Age = personUpdateDTO.Age;

        await _context.SaveChangesAsync();

        return new PersonResponseDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }

    public async Task<bool> DeletePersonAsync(Guid id)
    {
        var person = await _context.People.FindAsync(id);

        // Se a pessoa não for encontrada, retorna false
        if (person == null) return false;

        // Caso contrário, remove a pessoa e salva as mudanças
        _context.People.Remove(person);
        await _context.SaveChangesAsync();
        return true;
    }
}

using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.PersonDTO;
using ControleDeGastosAPI.Entities;
using ControleDeGastosAPI.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace ControleDeGastosAPI.Services;

public class PersonService
{
    private readonly ContextAPI _context;

    // injeção de dependência do ContextAPI para acessar o banco de dados
    public PersonService(ContextAPI context)
    {
        _context = context;
    }

    public async Task<PersonResponseDTO> CreatePersonAsync(PersonCreateDTO personCreateDTO)
    {
        // Essas validações são barradas antes da controller (DataAnnotations das Entities), mas por via das dúvidas deixei aqui também.
        if (personCreateDTO.Name == null) throw new Exception("O nome da pessoa é obrigatório.");
        if (personCreateDTO.Name.Length > 200 ) throw new Exception("O nome da pessoa deve ter no máximo 200 caracteres.");
        if (personCreateDTO.Age < 0 || personCreateDTO.Age > 150) throw new Exception("A idade da pessoa deve ser entre 0 e 150 anos.");

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

    public async Task<PersonResponseDTO> GetPersonByIdAsync(Guid id)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null) return null;

        return new PersonResponseDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
        };
    }

    public async Task<PersonResponseDTO?> UpdatePersonAsync(Guid id, PersonUpdateDTO personUpdateDTO)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null) return null;

        // CORREÇÃO DE BUG
        // Verifica se a idade vai ser menor que 18.
        // Se sim, verifica se a pessoa tem transações de receita.
        // Se a a pessoa tiver transações de receita, não permite a atualização.
        // Lança uma exeção:
        // mensagem de erro: "Não é permitido atualizar a idade para menor de 18 anos, pois a pessoa possui transações de receita."
        if (personUpdateDTO.Age < 18)
        {
            var hasIncomeTransactions = await _context.Transactions
                .AnyAsync(t => t.PersonId == id && t.Type == CategoryEnums.Income);

            if (hasIncomeTransactions)
            {
                throw new Exception("Não é permitido atualizar a idade para menor de 18 anos, pois a pessoa possui transações de receita.");
            }
        }

        // Essas validações são barradas antes da controller (DataAnnotations das Entities), mas por via das dúvidas deixei aqui também.
        if (personUpdateDTO.Name == null) throw new Exception("O nome da pessoa é obrigatório.");
        if (personUpdateDTO.Name.Length > 200) throw new Exception("O nome da pessoa deve ter no máximo 200 caracteres.");
        if (personUpdateDTO.Age < 0 || personUpdateDTO.Age > 150) throw new Exception("A idade da pessoa deve ser entre 0 e 150 anos.");

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

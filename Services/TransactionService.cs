using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.TransactionDTO;
using ControleDeGastosAPI.Enums;
using ControleDeGastosAPI.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastosAPI.Services;

public class TransactionService
{
    private readonly ContextAPI _context;

    // injeção de dependência do ContextAPI para acessar o banco de dados
    public TransactionService(ContextAPI context)
    {
        _context = context;
    }

    public async Task<TransactionResponseDTO> CreateTransactionAsync(TransactionCreateDTO transactionCreateDTO)
    {
        //Validar Pessoa e Idade
        var person = await _context.People.FindAsync(transactionCreateDTO.PersonId);

        if (person == null) throw new Exception("Pessoa não encontrada.");

        if (person.Age < 18 && transactionCreateDTO.Type != CategoryEnums.Expense)
            throw new Exception("Menores de idade só podem registrar despesas.");
        
        //Validar Categoria e compatibilidade
        var category = await _context.Categories.FindAsync(transactionCreateDTO.CategoryId);
        if (category == null) throw new Exception("Categoria não encontrada.");

        // Se a categoria não for "Ambas" (Both), ela deve ser igual ao tipo da transação.
        if (category.Purpose != CategoryEnums.Both && category.Purpose != transactionCreateDTO.Type)
            throw new Exception($"Esta categoria é apenas para {category.Purpose} e não aceita transações de {transactionCreateDTO.Type}.");
        

        var transaction = new Transaction
        {
            Description = transactionCreateDTO.Description,
            Value = transactionCreateDTO.Value,
            Type = transactionCreateDTO.Type,
            PersonId = transactionCreateDTO.PersonId,
            CategoryId = transactionCreateDTO.CategoryId
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return new TransactionResponseDTO
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Value = transaction.Value,
            Type = transaction.Type,
            PersonId = transaction.PersonId,
            CategoryId = transaction.CategoryId
        };
    }

    public async Task<List<TransactionResponseDTO>> GetAllTransactionsAsync()
    {
        var transactions = await _context.Transactions
            .Include(t => t.Person)   // "Entity Framework faz um JOIN com a tabela de Pessoas"
            .Include(t => t.Category) // "Entity Framework faz um JOIN com a tabela de Categorias"
            .ToListAsync();

        return transactions.Select(t => new TransactionResponseDTO
        {
            Id = t.Id,
            Description = t.Description,
            Value = t.Value,
            Type = t.Type,
            PersonId = t.PersonId,
            PersonName = t.Person?.Name,
            CategoryId = t.CategoryId,
            CategoryDescription = t.Category?.Description
        }).ToList();
    }
}

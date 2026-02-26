using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.DashboardDTO;
using ControleDeGastosAPI.DTOs.PersonDTO;
using ControleDeGastosAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastosAPI.Services;

public class DashboardService
{
    private readonly ContextAPI _context;

    public DashboardService(ContextAPI context)
    {
        _context = context;
    }

    public async Task<DashboardPeopleSummaryDTO> GetPeopleSummaryAsync()
    {
        // Busca todas as pessoas e calcula os totais
        // Garante que quem tem 0 transações também apareça na lista
        var peopleTotals = await _context.People
            .Select(p => new DashboardPersonTotalDTO
            {
                Person = new PersonResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                },

                // Soma transações do tipo Income (Receita)
                // Usa (decimal?) para evitar erro caso a pessoa não tenha transações
                TotalIncome = _context.Transactions
                    .Where(t => t.PersonId == p.Id && t.Type == CategoryEnums.Income)
                    .Sum(t => (decimal?)t.Value) ?? 0,

                // Soma transações do tipo Expense (Despesa)
                TotalExpense = _context.Transactions
                    .Where(t => t.PersonId == p.Id && t.Type == CategoryEnums.Expense)
                    .Sum(t => (decimal?)t.Value) ?? 0,

            }).ToListAsync();

        // Calcula o Balance (Saldo) individual e prepara os totais gerais
        foreach (var person in peopleTotals)
        {
            person.Balance = person.TotalIncome - person.TotalExpense;
        }

        // Monta o DTO de resumo final
        var summary = new DashboardPeopleSummaryDTO
        {
            PeopleTotals = peopleTotals,
            GrandTotalIncome = peopleTotals.Sum(p => p.TotalIncome),
            GrandTotalExpense = peopleTotals.Sum(p => p.TotalExpense)
        };

        summary.GrandBalance = summary.GrandTotalIncome - summary.GrandTotalExpense;

        return summary;
    }
}

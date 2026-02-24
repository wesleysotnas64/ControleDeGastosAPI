using Microsoft.EntityFrameworkCore;
using ControleDeGastosAPI.Entities;

namespace ControleDeGastosAPI.DBContext;

public class ContextAPI : DbContext
{
    public ContextAPI(DbContextOptions<ContextAPI> options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

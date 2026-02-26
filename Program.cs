using Scalar.AspNetCore; // Necessário para usar o MapScalarApiReference()
using dotenv.net;
using ControleDeGastosAPI.DBContext;
using Microsoft.EntityFrameworkCore;
using ControleDeGastosAPI.Services; // Necessário para usar o DotEnv.Load()

DotEnv.Load(); // Carrega as variáveis de ambiente do arquivo .env
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"); // Obtém a string de conexão do banco de dados

var builder = WebApplication.CreateBuilder(args);

//Registrando o ContextAPI
builder.Services.AddDbContext<ContextAPI>(options =>
{
    options.UseNpgsql(connectionString);
});

// Add services to the container.
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<DashboardService>();

//Para evitar erro de CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Comentei essa parte para que os endpoints fiquem visíveis mesmo em produção, mas se quiser deixar apenas para desenvolvimento, basta descomentar e colocar o código dentro do if (app.Environment.IsDevelopment())
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.MapOpenApi();
    app.MapScalarApiReference(); //Para visualizar os endpoints
//}

app.UseCors("AllowAll"); //Para evitar erro de CORS (Cross-Origin Resource Sharing)
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Application.Commands;
using Questao5.Application.Handlers;
using Questao5.Application.Queries;
using Questao5.Infrastructure.Repositories;
using Questao5.Infrastructure.Repositories.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

SQLitePCL.Batteries_V2.Init();


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(RegistrarMovimentacaoHandler));
builder.Services.AddMediatR(typeof(ConsultarSaldoHandler));

// sqlite
//builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<DatabaseConfig>(sp => new DatabaseConfig { ConnectionString = "Data Source=database.sqlite" });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=database.sqlite";
    return new SqliteConnection(connectionString);
});
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Registro de repositórios
builder.Services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IIdempotenciaRepository, IdempotenciaRepository>();

// Registro de Handlers
builder.Services.AddScoped<IRequestHandler<RegistrarMovimentacaoCommand, string>, RegistrarMovimentacaoHandler>();
builder.Services.AddScoped<IRequestHandler<ConsultarSaldoQuery, SaldoDto>, ConsultarSaldoHandler>();

var app = builder.Build();

// sqlite
app.Services.GetService<IDatabaseBootstrap>().Setup();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html



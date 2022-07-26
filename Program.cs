using Gof.Extensions;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Problema;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores;
using Gof.Patterns.Comportamentais.Command.Solucao.Commands;
using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade;
using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

// ChainOfResponsibility - Início
builder.Services.AddScoped<IProblemaChainOfResponsibility, ProblemaChainOfResponsibility>();
builder.Services.AddScoped<IValidadorTransacao, Validador>();
builder.Services.Decorate<IValidadorTransacao, ValidadorAcessorios>();
builder.Services.Decorate<IValidadorTransacao, ValidadorBanho>();
builder.Services.Decorate<IValidadorTransacao, ValidadorCama>();
builder.Services.Decorate<IValidadorTransacao, ValidadorMesa>();
builder.Services.Decorate<IValidadorTransacao, ValidadorRoupas>();
// ChainOfResponsibility - Fim

// Command - Início
builder.Services.AddScoped<IAgenda, Agenda>();
builder.Services.AddScoped<IAgendarCommand, AgendarCommand>();
builder.Services.AddScoped<ICarrinho, Carrinho>();
builder.Services.AddScoped<IPagarCommand, PagarCommand>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddScoped<IEnviarEmailCommand, EnviarEmailCommand>();
builder.Services.AddScoped<IAgenda, Agenda>();
builder.Services.AddScoped<IAgendarCommand, AgendarCommand>();
builder.Services.AddScoped<IFila, Fila>();
builder.Services.AddScoped<IColocarNaFilaCommand, ColocarNaFilaCommand>();
builder.Services.AddScoped<ICompra, Compra>();
builder.Services.AddScoped<IPagamento, Pagamento>();
// Command - Fim

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

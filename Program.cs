using Gof.Extensions;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Problema;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ChainOfResponsibility - Início
builder.Services.AddScoped<IProblemaChainOfResponsibility, ProblemaChainOfResponsibility>();
builder.Services.AddScoped<IValidadorTransacao, Validador>();
builder.Services.Decorate<IValidadorTransacao, ValidadorAcessorios>();
builder.Services.Decorate<IValidadorTransacao, ValidadorBanho>();
builder.Services.Decorate<IValidadorTransacao, ValidadorCama>();
builder.Services.Decorate<IValidadorTransacao, ValidadorMesa>();
builder.Services.Decorate<IValidadorTransacao, ValidadorRoupas>();
// ChainOfResponsibility - Fim

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

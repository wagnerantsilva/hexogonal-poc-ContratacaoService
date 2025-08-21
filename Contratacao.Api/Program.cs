using Contratacao.Adapters.Inbound.Controllers;
using Contratacao.Application.UseCases.ContratarProposta;
using Contratacao.Domain.Repositories;
using Contratacao.Infrastructure.Gateways;
using Contratacao.Infrastructure.Persistence;
using Contratacao.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(ContratacaoController).Assembly)
    .AddControllersAsServices();

builder.Services.AddScoped<IContratarPropostaUseCase, ContratarPropostaUseCase>();
builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRefitClient<IPropostaApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:7890/"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
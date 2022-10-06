using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MS_Financeiro.Context;
using MS_Financeiro.Dto;
using MS_Financeiro.Ioc;
using MS_Financeiro.Mapper;
using MS_Financeiro.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<FinancialContext>
    (options => options.UseSqlServer(
        "Data Source=localhost;Initial Catalog=CashFlow;Integrated Security=False;User ID=sa;Password=amojava@123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

builder.Services.AddSwaggerGen();

// IoC
builder.Services
    .AddApplicationServices()
    .AddRepositories();

//Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MS-Financeiro v1");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MS-Financeiro v1");
        c.RoutePrefix = "";
    });
}

app.MapPost("CashFlow", (CashFlowDto dto, ICashFlowService cashFlowService) =>
{
    cashFlowService.Add(dto);
    return Task.CompletedTask;
});

app.MapDelete("CashFlow/{id}", (long id, ICashFlowService cashFlowService) =>
{
    cashFlowService.Remove(id);
    return Task.CompletedTask;
});

app.MapGet("CashFlow/{id}", async (long id, ICashFlowService cashFlowService) =>
{
    return await cashFlowService.GetById(id);
});

app.Run();
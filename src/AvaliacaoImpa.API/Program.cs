using AvaliacaoImpa.API.Configurations;
using AvaliacaoImpa.API.GraphQL.mutation.card;
using AvaliacaoImpa.API.GraphQL.query;
using AvaliacaoImpa.API.GraphQL.query.card;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Adiciona o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Cadastro de Card", Version = "v1" });

    c.MapType<IFormFile>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "binary"
    });
});
builder.Services.EntityFrameworkConfiguration();
builder.Services.DependencyInjectionConfiguration();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<CardQuery>()
    .AddMutationType<CardMutation>()
    .AddUploadType();


var app = builder.Build();
app.UseRouting();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(options => options.WithOrigins()
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL(); // Mapeia automaticamente para "/graphql"
});

app.Run();

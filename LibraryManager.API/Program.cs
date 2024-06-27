using FluentValidation.AspNetCore;
using LibraryManager.API.Configurations;
using LibraryManager.API.Filters;
using LibraryManager.Application.Queries.GetAllBooks;
using LibraryManager.Application.Validators;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("LibraryCs");
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));

services.AddInfrastructure();

services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>());

builder.Services.AddControllers();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllBooksQuery>());

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowAllHeadersPolicy",
        policy =>
        {
            policy.WithOrigins("https://localhost:7256")
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowAllHeadersPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

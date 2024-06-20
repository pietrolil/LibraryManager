using LibraryManager.API.Configurations;
using LibraryManager.Application.Queries.GetAllBooks;
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

builder.Services.AddControllers();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllBooksQuery>());
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

app.UseAuthorization();

app.MapControllers();

app.Run();

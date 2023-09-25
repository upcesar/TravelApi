using TravelManagement.Api.Services;
using TravelManagement.Domain.Interfaces;
using TravelManagement.Infra.Data;
using TravelManagement.Infra.Data.Context;
using TravelManagement.Infra.Data.Repositories;
using TravelManagement.Infra.Data.UoW;
using TravelManagement.Infra.ExternalServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRouting(option => option.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITravelService, DummyTravelService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped(provider => new DatabaseConfig(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

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

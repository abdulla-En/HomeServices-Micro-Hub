using Microsoft.EntityFrameworkCore;
using User_Service.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the debendecy injection container.

// Swagger service to be used
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB service 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Controllers.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add SQL database connection
var connectionString = "Server=localhost\\MSSQLSERVER01;Database=TaskManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(connectionString));

// Used for temporary just in web save data
//builder.Services.AddDbContext<TaskContext>(opt => 
//    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

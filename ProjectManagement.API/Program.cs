using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<ProjectManagementDbContext>(options =>
    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine));  // Or use another provider like SQLite, PostgreSQL, etc.

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalHost3000", policy =>
    {
        //policy.AllowAnyOrigin()    // or .WithOrigins("http://localhost:3000") to restrict
        //      .AllowAnyMethod()
        //      .AllowAnyHeader();
        policy.WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddControllers();
    //.AddJsonOptions(x =>
    //{
    //    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    //    x.JsonSerializerOptions.WriteIndented = true;
    //});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS
app.UseCors("AllowLocalHost3000"); // 🔥 Add this before UseAuthorization()

app.UseAuthorization();

app.MapControllers();

app.Run();

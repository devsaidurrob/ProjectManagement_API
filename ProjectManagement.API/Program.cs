using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.API.Middlewares;
using ProjectManagement.API.Utility;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;
var jwtSecret = _configuration["Jwt:Key"];
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
        policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
    });
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ClockSkew = TimeSpan.Zero,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
//        };
//    });
//builder.Services.AddAuthorization(); // <- Required

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});
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

builder.Services.AddSingleton<JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS
app.UseCors("AllowLocalHost3000"); // 🔥 Add this before UseAuthorization()
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

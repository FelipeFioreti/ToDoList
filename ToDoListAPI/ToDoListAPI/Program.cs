using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ToDoListAPI;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Utils;
using ToDoListAPI.Domain.Interfaces;
using ToDoListAPI.Infrastructure.Context;
using ToDoListAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// Register utils
builder.Services.AddScoped<JwtUtils>();

// Register repositories
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<ITaskModelRepository, TaskModelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtTokenRepository, TokenRepository>();

// Configure JWT authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,   
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
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

app.UseAuthorization();

app.MapControllers();

app.Run();

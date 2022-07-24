using Business.Interface;
using Business.Service;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<ApplicatonDbContext>(x => x.UseSqlServer(builder.Configuration
    .GetConnectionString("TaskPlanner")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders();

//AutoMapper
builder.Services.AddAutoMapper(Assembly.Load("Dto"));

//AddScoped
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

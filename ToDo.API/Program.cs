using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Dto.User;
using ToDo.Application.Interfaces;
using ToDo.Application.Service;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using ToDo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, IUserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

AutoMapperDependenceInjection();

void AutoMapperDependenceInjection()
{
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
        //user
        cfg.CreateMap<User, UserDto>().ReverseMap();
        cfg.CreateMap<UserDto, CreateUserDto>().ReverseMap();
        cfg.CreateMap<CreateUserDto, User>().ReverseMap();
    });
    
    builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
}

builder.Services.AddSingleton(d => builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



    

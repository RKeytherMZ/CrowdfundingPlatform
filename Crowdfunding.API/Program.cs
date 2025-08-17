using Microsoft.EntityFrameworkCore;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Repositories;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.Service;
using CrowdFunding.Application.MapperProfiles;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// === 1. Configuración de Servicios ===

// Servicio para los controladores de la API
builder.Services.AddControllers();

// Servicios para Swagger (documentación de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de los repositorios y la unidad de trabajo
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();

// Configuración de AutoMapper
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<MappingProfile>();
});

// Configuración de los servicios de la lógica de negocio
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IStudentService, StudentService>();

// === 2. Configuración de la Aplicación (Middleware) ===

var app = builder.Build();

// Middleware de Swagger: Solo se usa en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para HTTPS
app.UseHttpsRedirection();

// Middleware para autorización
app.UseAuthorization();

// Middleware para enrutar los controladores
app.MapControllers();

// Inicia el servidor
app.Run();
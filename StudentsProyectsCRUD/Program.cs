using Microsoft.EntityFrameworkCore;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Infrastructure.Interfaces; 
using CrowdFunding.Infrastructure.Repositories; 
using CrowdFunding.Application.Contract; 
using CrowdFunding.Application.Service; 
using CrowdFunding.Application.MapperProfiles; 
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>(); 
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();



builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly); 
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IStudentService, StudentService>();
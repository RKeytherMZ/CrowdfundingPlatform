using AutoMapper;
using CrowdFunding.Application.DTOs.DonationDto;
using CrowdFunding.Application.DTOs.ProjectDto;
using CrowdFunding.Application.DTOs.StudentDto;
using CrowdFunding.Domain.Entities;


namespace YourProject.Application.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos para Project
        CreateMap<Project, ProjectDto>().ReverseMap(); // Permite mapear en ambas direcciones
        CreateMap<ProjectCreateDto, Project>(); // Para convertir DTO de creación a entidad
        CreateMap<ProjectUpdateDto, Project>(); // Para convertir DTO de actualización a entidad (para actualizar propiedades)

        // Mapeos para Donation
        CreateMap<Donation, DonationDto>().ReverseMap();
        CreateMap<DonationCreateDto, Donation>();

        // Mapeos para Student
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<StudentCreateDto, Student>();

    }
}
using AutoMapper;
using CrowdFunding.Application.DTOs.DonationDto;
using CrowdFunding.Application.DTOs.ProjectDto;
using CrowdFunding.Application.DTOs.StudentDto;
using CrowdFunding.Domain.Entities;


namespace CrowdFunding.Application.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos para Project
        // Mapeo explícito para la relación N:N
        CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));

        CreateMap<ProjectDto, Project>(); // Este es el .ReverseMap() de forma explícita

        CreateMap<ProjectCreateDto, Project>();
        CreateMap<ProjectUpdateDto, Project>();

        // Mapeos para Donation
        CreateMap<Donation, DonationDto>().ReverseMap();
        CreateMap<DonationCreateDto, Donation>();
        CreateMap<DonationUpdateDTO, Donation>();

        // Mapeos para Student
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();
    }
}
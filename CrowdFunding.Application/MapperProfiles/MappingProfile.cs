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
        CreateMap<Project, ProjectDto>().ReverseMap(); 
        CreateMap<ProjectCreateDto, Project>(); 
        CreateMap<ProjectUpdateDto, Project>(); 

        // Mapeos para Donation
        CreateMap<Donation, DonationDto>().ReverseMap();
        CreateMap<DonationCreateDto, Donation>();

        // Mapeos para Student
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<StudentCreateDto, Student>();

    }
}
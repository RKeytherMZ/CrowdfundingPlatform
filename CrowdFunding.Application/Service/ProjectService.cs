using System;
using System.Collections.Generic;
using AutoMapper;
using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.ProjectDto;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;

namespace CrowdFunding.Application.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectCreateDto createDto)
        {

            var project = _mapper.Map<Project>(createDto);


            foreach (var studentId in createDto.StudentIds)
            {

                var student = await _unitOfWork.Students.GetByIdAsync(studentId);

 
                if (student != null)
                {

                    project.Students.Add(student);
                }
            }
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task UpdateProjectAsync(int id, ProjectUpdateDto updateDto)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            _mapper.Map(updateDto, project);


            if (updateDto.Status == "Completed" && project.AmountRaised < project.FundingGoal)
            {
               throw new InvalidOperationException("Cannot complete project if funding goal is not met.");
            }

            _unitOfWork.Projects.Update(project); 
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }


            _unitOfWork.Projects.Delete(project);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsByStudentIdAsync(int studentId)
        {
            var projects = await _unitOfWork.Projects.GetProjectsByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<IEnumerable<ProjectDto>> GetActiveProjectsAsync()
        {
            var projects = await _unitOfWork.Projects.GetActiveProjectsAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
    }
}

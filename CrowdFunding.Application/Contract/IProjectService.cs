using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Application.DTOs.ProjectDto;

namespace CrowdFunding.Application.Contract
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();

        Task<ProjectDto?> GetProjectByIdAsync(int id);

        Task<ProjectDto> CreateProjectAsync(ProjectCreateDto createDto);

        Task UpdateProjectAsync(int id, ProjectUpdateDto updateDto);

        Task DeleteProjectAsync(int id);

        Task<IEnumerable<ProjectDto>> GetProjectsByStudentIdAsync(int studentId);
        Task<IEnumerable<ProjectDto>> GetActiveProjectsAsync();
    }
}

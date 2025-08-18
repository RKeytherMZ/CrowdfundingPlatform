using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Domain.Entities;


namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {

        Task<IEnumerable<Project>> GetProjectsByStudentIdAsync(int studentId);
        Task<IEnumerable<Project>> GetActiveProjectsAsync();      
        Task<Project?> GetProjectWithDetailsAsync(int id);
    }
}

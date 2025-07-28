using Microsoft.EntityFrameworkCore;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Infrastructure.Interfaces;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetProjectsByStudentIdAsync(int studentId)
        {
            return await _dbSet.Where(p => p.StudentId == studentId).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetActiveProjectsAsync()
        {
           
            return await _dbSet.Where(p => p.Status == "Active" && p.EndDate >= DateTime.UtcNow)
                               .Include(p => p.Student) 
                               .OrderByDescending(p => p.CreatedAt)
                               .ToListAsync();
        }

        public async Task<Project?> GetProjectWithDetailsAsync(int id)
        {
          
            return await _dbSet.Include(sp => sp.Donations)
                               .Include(sp => sp.Student)
                               .FirstOrDefaultAsync(sp => sp.Id == id);
        }
    }
}

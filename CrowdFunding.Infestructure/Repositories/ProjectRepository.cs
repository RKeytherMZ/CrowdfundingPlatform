using Microsoft.EntityFrameworkCore;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Infrastructure.Interfaces;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetProjectsByStudentIdAsync(int studentId)
        {
            return await _dbSet
                .Where(p => p.Students.Any(s => s.Id == studentId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetActiveProjectsAsync()
        {

            return await _dbSet
            .Where(p => p.Status == "Active" && p.EndDate >= DateTime.UtcNow)
            .Include(p => p.Students) 
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
        }

        public async Task<Project?> GetProjectWithDetailsAsync(int id)
        {

            return await _dbSet
             .Include(sp => sp.Donations)
             .Include(sp => sp.Students) // 🔹 colección N:N
             .FirstOrDefaultAsync(sp => sp.Id == id);
        }
    }
}

using System;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student?> GetStudentWithProjectsAsync(int studentId)
        {
            // Incluye la colección de proyectos cuando recuperas al estudiante
            return await _dbSet.Include(s => s.Projects)
                               .FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}

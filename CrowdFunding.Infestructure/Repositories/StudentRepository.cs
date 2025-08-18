using System;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<Student?> GetStudentWithProjectsAsync(int studentId)
        {
           
            return await _dbSet.Include(s => s.Projects)
                               .FirstOrDefaultAsync(s => s.Id == studentId);
        }
        public override void Delete(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}

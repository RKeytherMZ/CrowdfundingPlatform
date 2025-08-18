using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Domain.Entities;

namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student?> GetByEmailAsync(string email);
        Task<Student?> GetStudentWithProjectsAsync(int studentId);
    }
}

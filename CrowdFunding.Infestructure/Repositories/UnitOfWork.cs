using CrowdFunding.Domain.Entities;

using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Infrastructure.Interfaces;
using StudentsProyectsCRUD.Data;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public Repository<Student> Students { get; }
        public Repository<Donation> Donations { get; }
        public Repository<Project> Projects { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Students = new Repository<Student>(_context);
            Donations = new Repository<Donation>(_context);
            Projects = new Repository<Project>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

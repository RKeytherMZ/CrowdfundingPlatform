using System;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Data;



namespace CrowdFunding.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IStudentRepository? _students;
        private IProjectRepository? _projects;
        private IDonationRepository? _donations; 

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        // Propiedades públicas para acceder a los repositorios
        public IStudentRepository Students => _students ??= new StudentRepository(_context);
        public IProjectRepository Projects => _projects ??= new ProjectRepository(_context);
        public IDonationRepository Donations => _donations ??= new DonationRepository(_context);


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public void Dispose()
        {
            _context.Dispose(); 
            GC.SuppressFinalize(this); 
        }
    }
}

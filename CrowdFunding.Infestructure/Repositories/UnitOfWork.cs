using System;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Data;



namespace CrowdFunding.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Campos privados para almacenar las instancias de los repositorios
        // Se usa el patrón de inicialización lazy (??=) para crearlos solo si se acceden
        private IStudentRepository? _students;
        private IProjectRepository? _projects;
        private IGenericRepository<Donation>? _donations; // Usamos el genérico para Donation si no hay métodos específicos

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        // Propiedades públicas para acceder a los repositorios
        public IStudentRepository Students => _students ??= new StudentRepository(_context);
        public IProjectRepository Projects => _projects ??= new ProjectRepository(_context);
        public IGenericRepository<Donation> Donations => _donations ??= new GenericRepository<Donation>(_context);


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

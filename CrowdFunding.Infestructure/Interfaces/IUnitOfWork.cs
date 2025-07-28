using CrowdFunding.Domain.Repository;
using CrowdFunding.Domain.Entities;

namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Donation> Donations { get; }
        IRepository<Project> Projects { get; }
        Task<int> SaveAsync();
    }
}

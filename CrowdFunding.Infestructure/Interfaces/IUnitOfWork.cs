
using CrowdFunding.Domain.Entities;

namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {

        IStudentRepository Students { get; }
        IProjectRepository Projects { get; }
        IGenericRepository<Donation> Donations { get; }
        Task<int> CompleteAsync();
    }
}

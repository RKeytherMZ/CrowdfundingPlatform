
using CrowdFunding.Domain.Entities;

namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {

        IStudentRepository Students { get; }
        IProjectRepository Projects { get; }
        IDonationRepository Donations { get; }
        Task<int> CompleteAsync();
    }
}

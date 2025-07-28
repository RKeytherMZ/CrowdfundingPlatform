using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Domain.Entities;

namespace CrowdFunding.Infrastructure.Interfaces
{
    public interface IDonationRepository : IGenericRepository<Donation>
    {
        Task<IEnumerable<Donation>> GetDonationsByStudentProjectIdAsync(int studentProjectId);
    }
}

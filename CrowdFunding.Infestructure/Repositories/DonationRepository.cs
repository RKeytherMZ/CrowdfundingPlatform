using System;
using CrowdFunding.Domain.Entities;
using CrowdFunding.Infrastructure.Interfaces;
using CrowdFunding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrowdFunding.Infrastructure.Repositories
{
    public class DonationRepository : GenericRepository<Donation>, IDonationRepository
    {
        public DonationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Donation>> GetDonationsByStudentProjectIdAsync(int studentProjectId)
        {
            return await _dbSet.Where(d => d.ProjectId == studentProjectId)
                               .OrderByDescending(d => d.DonationDate)
                               .ToListAsync();
        }
    }
}

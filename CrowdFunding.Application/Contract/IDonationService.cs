using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Application.DTOs.DonationDto;

namespace CrowdFunding.Application.Contract
{
    public interface IDonationService
    {
        Task<DonationDto> CreateDonationAsync(DonationCreateDto createDto);

        Task<IEnumerable<DonationDto>> GetDonationsByProjectIdAsync(int projectId);

        Task<IEnumerable<DonationDto>> GetAllDonationsAsync();

        Task UpdateDonationAsync(int id, DonationUpdateDTO updateDto);

        Task DeleteDonationAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.DonationDto
{
    public class DonationUpdateDTO
    {
        public decimal? Amount { get; set; }
        public string? DonorName { get; set; }
        public string? DonorEmail { get; set; }
        public int? ProjectId { get; set; }
    }
}

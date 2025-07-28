using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Domain.Entities
{
    public class Donation : BaseEntity
    {

        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; } = DateTime.UtcNow;
        public string? DonorName { get; set; }
        public string? DonorEmail { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

    }
}

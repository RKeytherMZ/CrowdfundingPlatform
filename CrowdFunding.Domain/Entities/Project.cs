using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Domain.Entities
{
    public class Project : BaseEntity
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal FundingGoal { get; set; }
        public decimal AmountRaised { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; } = "Active"; // Ej: "Active", "Completed", "Closed", "Canceled"

        public ICollection<Student> Students { get; set; } = new List<Student>();


        public ICollection<Donation> Donations { get; set; } = new List<Donation>();

        public void ReceiveDonation(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Donation amount must be positive.", nameof(amount));
            }

            if (Status == "Completed" || Status == "Closed")
            {
                throw new InvalidOperationException("Cannot add donations to a project that is already completed or closed.");
            }

            AmountRaised += amount;

            if (AmountRaised >= FundingGoal)
            {
                Status = "Completed";
            }
        }


    }
}

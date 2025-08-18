using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.ProjectDto
{
    public class ProjectUpdateDto
    {
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; } 

        public string? Description { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Funding goal must be positive.")]
        public decimal? FundingGoal { get; set; }

        public DateTime? StartDate { get; set; }

       
        public DateTime? EndDate { get; set; }

        public string? Status { get; set; } 
    }
}

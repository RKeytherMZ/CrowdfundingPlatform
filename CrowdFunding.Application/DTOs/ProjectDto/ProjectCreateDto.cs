using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrowdFunding.Application.DTOs.ProjectDto
{
    public class CreateProjectDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Funding goal is required.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Funding goal must be positive.")]
        public decimal FundingGoal { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        // Usaremos una validación personalizada, que puedes crear en un archivo separado
        [FutureDate(ErrorMessage = "End date must be in the future and after the start date.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        public int StudentId { get; set; }
    }


}

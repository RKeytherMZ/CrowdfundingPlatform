using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFunding.Application.DTOs.ProjectDto;

namespace CrowdFunding.Application.Utility.ValidationsAttribute
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                var createDto = (ProjectCreateDto)validationContext.ObjectInstance;

                if (dateTime <= DateTime.UtcNow)
                {
                  
                    return new ValidationResult(this.ErrorMessage ?? "End date must be in the future.");
                }
                if (dateTime <= createDto.StartDate)
                {
                   
                    return new ValidationResult(this.ErrorMessage ?? "End date must be after the start date.");
                }
            }
            return ValidationResult.Success;
        }
    }
}

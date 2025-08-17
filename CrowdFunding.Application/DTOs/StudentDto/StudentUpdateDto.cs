using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.StudentDto
{
    public class StudentUpdateDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public int? Age { get; set; }
        public string? Institution { get; set; }
        public string? Email { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Domain.Entities
{
    public class Student : BaseEntity
    {

            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string? PasswordHash { get; set; }
            public string Institution { get; set; } = string.Empty;

            public ICollection<Project> Proyectos { get; set; } = new List<Project>();


        }
}



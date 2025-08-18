using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Domain.Entities
{
    public class Student : BaseEntity
    {

            public string Name { get; set; } = string.Empty;

            public string LastName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Bio { get; set; } = string.Empty;

            public int Age { get; set; }


            public string Institution { get; set; } = string.Empty;

            public ICollection<Project> Projects { get; set; } = new List<Project>();


        }
}



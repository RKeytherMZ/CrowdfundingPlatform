using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Fecha de creación, por defecto UTC
        public DateTime? UpdatedAt { get; set; } // Fecha de última actualización 

    }
}

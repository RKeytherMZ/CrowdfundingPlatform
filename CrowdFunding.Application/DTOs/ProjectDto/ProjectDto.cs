using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.ProjectDto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal MetaFinanciera { get; set; }
        public decimal MontoRecaudado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int StudentId { get; set; } 



    }
}

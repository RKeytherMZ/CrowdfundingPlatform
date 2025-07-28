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
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public decimal MetaFinanciera { get; set; }

        public decimal MontoRecaudado { get; set; } = 0;

        public int EstudianteId { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.DonationDto
{
    public class DonationDto
    {
        public int Id { get; set; }

        public string Donante { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public int ProyectoId { get; set; }

        public string ProyectoTitulo { get; set; } 


    }
}

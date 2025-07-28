using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.Application.DTOs.DonationDto
{
    public class DonationUpdateDto
    {

        public int Id { get; set; }
        public string Donante { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ProyectoId { get; set; }



    }
}

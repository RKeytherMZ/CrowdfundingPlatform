using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.DonationDto;
using CrowdFunding.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace StudentsProyectsCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // POST: api/Donations
        [HttpPost]
        [ProducesResponseType(typeof(DonationDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        public async Task<ActionResult<DonationDto>> PostDonation([FromBody] DonationCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var createdDonation = await _donationService.CreateDonationAsync(createDto);
                
                return StatusCode((int)HttpStatusCode.Created, createdDonation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Project with ID {createDto.ProjectId} not found.");
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DonationDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DonationDto>>> GetAllDonations()
        {
            var donations = await _donationService.GetAllDonationsAsync();

            // Si la lista de donaciones está vacía, puedes devolver un Ok vacío o un NotFound.
            if (donations == null || !donations.Any())
            {
                return Ok(new List<DonationDto>());
                // o return NotFound("No se encontraron donaciones.");
            }

            return Ok(donations);
        }


        // GET: api/Donations/ByProject/1
        [HttpGet("ByProject/{projectId}")]
        [ProducesResponseType(typeof(IEnumerable<DonationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        public async Task<ActionResult<IEnumerable<DonationDto>>> GetDonationsByProject(int projectId)
        { 
            var donations = await _donationService.GetDonationsByProjectIdAsync(projectId);

            return Ok(donations); 
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] DonationUpdateDTO updateDto)
        {
            try
            {
                // Se le pasa el ID y el DTO al servicio
                await _donationService.UpdateDonationAsync(id, updateDto);
                return NoContent(); // 204 No Content para indicar éxito
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404 Not Found si no se encuentra la donación
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request si los datos son inválidos
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            try
            {
                // Llama al servicio para que maneje la eliminación
                await _donationService.DeleteDonationAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Retorna 404 si la donación no se encontró
            }
        }
    }
}

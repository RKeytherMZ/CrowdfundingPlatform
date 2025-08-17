using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.DonationDto;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Donations/ByProject/1
        [HttpGet("ByProject/{projectId}")]
        [ProducesResponseType(typeof(IEnumerable<DonationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        public async Task<ActionResult<IEnumerable<DonationDto>>> GetDonationsByProject(int projectId)
        { 
            var donations = await _donationService.GetDonationsByProjectIdAsync(projectId);

            return Ok(donations); 
        }
    }
}

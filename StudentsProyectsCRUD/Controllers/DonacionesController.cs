using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Domain.Entities;

namespace StudentsProyectsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonacionesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetDonaciones()
        {
            return await _context.Donations.Include(d => d.Proyecto).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonacion(int id)
        {
            var donacion = await _context.Donations.Include(d => d.Proyecto)
                                                    .FirstOrDefaultAsync(d => d.Id == id);

            if (donacion == null)
            {
                return NotFound();
            }

            return donacion;
        }

        
        [HttpPost]
        public async Task<ActionResult<Donation>> PostDonacion(Donation donacion)
        {
            _context.Donations.Add(donacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacion", new { id = donacion.Id }, donacion);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacion(int id, Donation donacion)
        {
            if (id != donacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(donacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacion(int id)
        {
            var donacion = await _context.Donations.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            _context.Donations.Remove(donacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionExists(int id)
        {
            return _context.Donations.Any(e => e.Id == id);
        }
    }
}

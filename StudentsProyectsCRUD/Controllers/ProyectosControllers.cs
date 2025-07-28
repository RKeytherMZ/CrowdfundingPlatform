using Microsoft.AspNetCore.Mvc;
using CrowdFunding.Infrastructure.Data;
using CrowdFunding.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentsProyectsCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProyectosController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProyectos()
        {
            return await _context.Projects.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProyecto(int id)
        {
            var proyecto = await _context.Projects.FindAsync(id);

            if (proyecto == null)
                return NotFound();

            return proyecto;
        }

        
        [HttpPost]
        public async Task<ActionResult<Project>> PostProyecto(Project proyecto)
        {
            _context.Projects.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Project proyecto)
        {
            if (id != proyecto.Id)
                return BadRequest();

            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Projects.FindAsync(id);
            if (proyecto == null)
                return NotFound();

            _context.Projects.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using CrowdFunding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CrowdFunding.Domain.Entities;

namespace CrowdfundingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var estudiante = await _context.Students.FindAsync(id);
            if (estudiante == null) return NotFound();
            return estudiante;
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student estudiante)
        {
            _context.Students.Add(estudiante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = estudiante.Id }, estudiante);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Student estudiante)
        {
            if (id != estudiante.Id) return BadRequest();
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Students.FindAsync(id);
            if (estudiante == null) return NotFound();
            _context.Students.Remove(estudiante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

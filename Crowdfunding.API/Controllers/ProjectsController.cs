using CrowdFunding.Application.Contract;
using CrowdFunding.Application.DTOs.ProjectDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StudentsProyectsCRUD.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects); 
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project); 
        }

        // POST: api/Projects
        [HttpPost]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        public async Task<ActionResult<ProjectDto>> PostProject([FromBody] ProjectCreateDto createDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var createdProject = await _projectService.CreateProjectAsync(createDto);
                return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
             
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while creating the project.");
            }
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> PutProject(int id, [FromBody] ProjectUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _projectService.UpdateProjectAsync(id, updateDto);
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); 
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); 
            }
            catch (InvalidOperationException ex) 
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        // GET: api/Projects/ByStudent/1
        [HttpGet("ByStudent/{studentId}")]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsByStudent(int studentId)
        {
            var projects = await _projectService.GetProjectsByStudentIdAsync(studentId);
            return Ok(projects);
        }

        // GET: api/Projects/Active
        [HttpGet("Active")]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetActiveProjects()
        {
            var projects = await _projectService.GetActiveProjectsAsync();
            return Ok(projects);
        }
    }
}

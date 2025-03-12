using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Attribute;
using Portfolio.Services;
using Portfolio.ViewModel;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtAuthorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var projects = await _projectService.getAll();
                return Ok(projects);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("{projectId}")]
        public async Task<IActionResult> getById(int projectId)
        {
            try
            {
                var project = await _projectService.getById(projectId);
                return Ok(project);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> add(ProjectInsVM project)
        {
            try
            {
                var projectIns = await _projectService.add(project);
                return Ok(projectIns);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> update(ProjectUpdVM project)
        {
            try
            {
                var projectUpd = await _projectService.update(project);
                return Ok(projectUpd);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

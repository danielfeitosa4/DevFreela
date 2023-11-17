using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        // api/projects/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel newProjectInputModel)
        {
            if (newProjectInputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(newProjectInputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, newProjectInputModel);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProjectInputModel)
        {
            if (updateProjectInputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(updateProjectInputModel);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }
        
        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createCommentInputModel)
        {
            _projectService.CreateComment(createCommentInputModel);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}

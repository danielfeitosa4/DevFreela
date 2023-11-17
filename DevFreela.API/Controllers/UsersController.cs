using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ExampleClass _exampleClass;
        public UsersController(ExampleClass exampleClass)
        {
            _exampleClass = exampleClass;
        }

        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // api/users/
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, model);
        }

        // api/users/1/login
        [HttpPut("{id}")]
        public IActionResult Login(int id, [FromBody] LoginModel model)
        {
             return NoContent();
        }
    }
}

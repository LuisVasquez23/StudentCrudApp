using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudApp.Manager;
using StudentCrudApp.ViewModels;

namespace StudentCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _studentManager.GetAll(page, pageSize);

            return Ok(result);
        }

        [HttpGet("GetStudentById/{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _studentManager.GetById(userId);
            return Ok(result);
        }
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> Create([FromBody] StudentViewModel model)
        {
            var result = await _studentManager.Create(model);

            return Ok(result);
        }
        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> Update(int id, StudentViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest("El usuario a actualizar no coinciden los datos");
            }

            var result = await _studentManager.Update(model);
            return Ok(result);
        }
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentManager.Delete(id);
            return Ok(result);
        }
    }
}

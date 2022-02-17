using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetStudents()
        {
            var students = await _repo.GetStudentsAsync();

            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await _repo.GetStudentByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var result = await _repo.InsertStudentAsync(student);

            return CreatedAtRoute("GetStudent", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            
            var result = await _repo.UpdateStudentAsync(id, student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _repo.DeleteStudentAsync(id);

            return result == null ? NotFound() : NoContent();
        }


    }
}
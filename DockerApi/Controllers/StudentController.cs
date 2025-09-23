using DockerApi.Entities;
using DockerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DockerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateAsync([FromBody] Student student)
    {
        var studentId = await studentService.CreateAsync(student);

        return Ok(studentId);
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAllAsync()
    {
        return await studentService.GetAllAsync();
    }
}

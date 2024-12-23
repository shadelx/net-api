using Microsoft.AspNetCore.Mvc;

namespace student_api;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    //endpoints
    [HttpPost("save")]
    public BaseResponse CreateStudent(CreateStudentRequest request)
    {
        return _studentService.CreateStudent(request);
    }

    [HttpGet("list")]
    public BaseResponse StudentList()
    {
        return _studentService.StudentList();
    }

    [HttpGet("{id}")]
    public BaseResponse GetStudentById(long id)
    {
        return _studentService.GetStudentById(id);
    }
}

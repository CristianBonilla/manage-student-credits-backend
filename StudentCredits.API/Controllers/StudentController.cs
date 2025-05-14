using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCredits.API.Filters;
using StudentCredits.Contracts.DTO.Student;
using StudentCredits.Contracts.DTO.Subject;
using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class StudentController(IMapper mapper, IStudentService studentService) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly IStudentService _studentService = studentService;

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddStudent([FromBody] StudentRequest studentRequest)
  {
    StudentEntity student = _mapper.Map<StudentEntity>(studentRequest);
    StudentEntity addedStudent = await _studentService.AddStudent(student);
    StudentResponse studentResponse = _mapper.Map<StudentResponse>(addedStudent);

    return CreatedAtAction(nameof(AddStudent), studentResponse);
  }

  [HttpPost("{studentId}")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentDetailResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AssignSubject(Guid studentId, [FromQuery] Guid teacherId, [FromQuery] Guid subjectId)
  {
    StudentDetailEntity studentDetail = await _studentService.AssignSubject(studentId, teacherId, subjectId);
    StudentDetailResponse studentDetailResponse = _mapper.Map<StudentDetailResponse>(studentDetail);

    return CreatedAtAction(nameof(AssignSubject), studentDetailResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<StudentResult>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<StudentResult> GetStudents()
  {
    var students = _studentService.GetStudents();
    await foreach (var student in students)
      yield return _mapper.Map<StudentResult>(student);
  }

  [HttpGet("{studentId}/subjects")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<SubjectResponse>))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IActionResult GetSubjectsByStudentId(Guid studentId)
  {
    var subjects = _studentService
      .GetSubjectsByStudentId(studentId)
      .Select(_mapper.Map<SubjectResponse>);

    return Ok(subjects);
  }

  [HttpGet("{studentId}/total-credits")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetTotalCreditsByStudentId(Guid studentId)
  {
    decimal totalCredits = await _studentService.GetTotalCreditsByStudentId(studentId);

    return Ok(totalCredits);
  }


  [HttpGet("{studentId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResult))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindStudentById(Guid studentId)
  {
    var student = await _studentService.FindStudentById(studentId);

    return Ok(_mapper.Map<StudentResult>(student));
  }
}

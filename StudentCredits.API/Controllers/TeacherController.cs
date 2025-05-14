using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCredits.API.Filters;
using StudentCredits.Contracts.DTO.Subject;
using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class TeacherController(IMapper mapper, ITeacherService teacherService) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly ITeacherService _teacherService = teacherService;

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddTeacher([FromBody] TeacherRequest teacherRequest)
  {
    TeacherEntity teacher = _mapper.Map<TeacherEntity>(teacherRequest);
    TeacherEntity addedTeacher = await _teacherService.AddTeacher(teacher);
    TeacherResponse teacherResponse = _mapper.Map<TeacherResponse>(addedTeacher);

    return CreatedAtAction(nameof(AddTeacher), teacherResponse);
  }

  [HttpPost("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherDetailResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AssignSubject(Guid teacherId, [FromQuery] Guid subjectId)
  {
    TeacherDetailEntity teacherDetail = await _teacherService.AssignSubject(teacherId, subjectId);
    TeacherDetailResponse teacherDetailResponse = _mapper.Map<TeacherDetailResponse>(teacherDetail);

    return CreatedAtAction(nameof(AssignSubject), teacherDetailResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<TeacherResult>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<TeacherResult> GetTeachers()
  {
    var teachers = _teacherService.GetTeachers();
    await foreach (var teacher in teachers)
      yield return _mapper.Map<TeacherResult>(teacher);
  }

  [HttpGet("{teacherId}/subjects")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<SubjectResponse>))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IActionResult GetSubjectsByTeacherId(Guid teacherId)
  {
    var subjects = _teacherService
      .GetSubjectsByTeacherId(teacherId)
      .Select(_mapper.Map<SubjectResponse>);

    return Ok(subjects);
  }

  [HttpGet("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherResult))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindTeacherById(Guid teacherId)
  {
    var teacher = await _teacherService.FindTeacherById(teacherId);

    return Ok(_mapper.Map<TeacherResult>(teacher));
  }
}

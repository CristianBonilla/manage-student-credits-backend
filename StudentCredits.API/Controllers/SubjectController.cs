using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCredits.API.Filters;
using StudentCredits.Contracts.DTO.Subject;
using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;

namespace StudentCredits.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class SubjectController(IMapper mapper, ISubjectService subjectService) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly ISubjectService _subjectService = subjectService;

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubjectResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddSubject([FromBody] SubjectRequest subjectRequest)
  {
    SubjectEntity subject = _mapper.Map<SubjectEntity>(subjectRequest);
    SubjectEntity addedSubject = await _subjectService.AddSubject(subject);
    SubjectResponse subjectResponse = _mapper.Map<SubjectResponse>(addedSubject);

    return CreatedAtAction(nameof(AddSubject), subjectResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<SubjectResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<SubjectResponse> GetSubjects()
  {
    var subjects = _subjectService.GetSubjects();
    await foreach (SubjectEntity subject in subjects)
      yield return _mapper.Map<SubjectResponse>(subject);
  }

  [HttpGet("{subjectId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindSubjectById(Guid subjectId)
  {
    var subject = await _subjectService.FindSubjectById(subjectId);

    return Ok(_mapper.Map<SubjectResponse>(subject));
  }
}

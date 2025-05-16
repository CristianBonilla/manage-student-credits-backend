using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Helpers;
using StudentCredits.Helpers.Exceptions;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Domain.Services;

public class SubjectService(
  IStudentCreditsRepositoryContext context,
  ISubjectRepository subjectRepository,
  ITeacherDetailRepository teacherDetailRepository) : ISubjectService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly ISubjectRepository _subjectRepository = subjectRepository;
  readonly ITeacherDetailRepository _teacherDetailRepository = teacherDetailRepository;

  public async Task<SubjectEntity> AddSubject(SubjectEntity subject)
  {
    bool existingSubject = _subjectRepository
      .GetAll()
      .Any(currentSubject => StringCommonHelper.IsEquivalent(currentSubject.Name, subject.Name));
    if (existingSubject)
      throw SubjectExceptionsHelper.BadRequest(subject.Name);
    SubjectEntity addedSubject = _subjectRepository.Create(subject);
    _ = await _context.SaveAsync();

    return addedSubject;
  }

  public IAsyncEnumerable<SubjectEntity> GetSubjects() => _subjectRepository.GetAll(subject => subject.OrderBy(order => order.Name)).ToAsyncEnumerable();

  public IAsyncEnumerable<TeacherEntity> GetTeachersBySubjectId(Guid subjectId)
  {
    CheckSubjectById(subjectId);
    var teachers = _teacherDetailRepository
      .GetByFilter(
        teacherDetail => teacherDetail.SubjectId == subjectId,
        teacherDetails => teacherDetails
          .OrderBy(order => order.Teacher.DocumentNumber)
          .ThenBy(order => order.Teacher.Firstname)
          .ThenBy(order => order.Teacher.Lastname),
        teacherDetail => teacherDetail.Teacher)
      .Select(teacherDetail => teacherDetail.Teacher)
      .ToAsyncEnumerable();

    return teachers;
  }

  public Task<SubjectEntity> FindSubjectById(Guid subjectId)
  {
    SubjectEntity subject = _subjectRepository.Find([subjectId]) ?? throw SubjectExceptionsHelper.NotFound(subjectId);

    return Task.FromResult(subject);
  }

  private void CheckSubjectById(Guid subjectId)
  {
    bool existingSubject = _subjectRepository.Exists(subject => subject.SubjectId == subjectId);
    if (!existingSubject)
      throw SubjectExceptionsHelper.NotFound(subjectId);
  }
}

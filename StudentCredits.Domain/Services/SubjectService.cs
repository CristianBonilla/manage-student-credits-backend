using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Helpers;
using StudentCredits.Helpers.Exceptions;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Domain.Services;

public class SubjectService(
  IStudentCreditsRepositoryContext context,
  ISubjectRepository subjectRepository) : ISubjectService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly ISubjectRepository _subjectRepository = subjectRepository;

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

  public Task<SubjectEntity> FindSubjectById(Guid subjectId)
  {
    SubjectEntity subject = _subjectRepository.Find([subjectId]) ?? throw SubjectExceptionsHelper.NotFound(subjectId);

    return Task.FromResult(subject);
  }
}

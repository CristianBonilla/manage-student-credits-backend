using StudentCredits.Domain.Entities;

namespace StudentCredits.Contracts.Services;

public interface ISubjectService
{
  Task<SubjectEntity> AddSubject(SubjectEntity subject);
  IAsyncEnumerable<SubjectEntity> GetSubjects();
  IAsyncEnumerable<TeacherEntity> GetTeachersBySubjectId(Guid subjectId);
  Task<SubjectEntity> FindSubjectById(Guid subjectId);
}

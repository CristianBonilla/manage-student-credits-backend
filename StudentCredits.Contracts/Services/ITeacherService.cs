using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Contracts.Services;

public interface ITeacherService
{
  Task<TeacherEntity> AddTeacher(TeacherEntity teacher);
  Task<TeacherDetailEntity> AssignSubject(Guid teacherId, Guid subjectId, decimal credits = TeacherCommonValues.CREDITS);
  IAsyncEnumerable<(TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails)> GetTeachers();
  IAsyncEnumerable<SubjectEntity> GetSubjectsByTeacherId(Guid teacherId);
  Task<TeacherEntity> FindTeacherById(Guid teacherId);
}

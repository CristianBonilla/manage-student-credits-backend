using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Contracts.Services;

public interface IStudentService
{
  Task<StudentEntity> AddStudent(StudentEntity student);
  Task<StudentDetailEntity> AssignSubject(Guid studentId, Guid teacherId, Guid subjectId);
  IAsyncEnumerable<(StudentEntity Student, IEnumerable<StudentDetailEntity> Details)> GetStudents();
  IAsyncEnumerable<SubjectEntity> GetSubjectsByStudentId(Guid studentId);
  Task<decimal> GetTotalCreditsByStudentId(Guid studentId);
  Task<StudentEntity> FindStudentById(Guid studentId);
}

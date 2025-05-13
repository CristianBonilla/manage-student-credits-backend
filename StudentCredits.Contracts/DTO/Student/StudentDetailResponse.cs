using StudentCredits.Contracts.DTO.Subject;
using StudentCredits.Contracts.DTO.Teacher;

namespace StudentCredits.Contracts.DTO.Student;

public class StudentDetailResponse
{
  public required Guid StudentId { get; set; }
  public required TeacherDetailResponse TeacherDetail { get; set; }
  public required DateTimeOffset Created { get; set; }
}

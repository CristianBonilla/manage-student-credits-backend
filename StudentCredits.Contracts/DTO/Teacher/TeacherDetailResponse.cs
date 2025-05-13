using StudentCredits.Contracts.DTO.Subject;

namespace StudentCredits.Contracts.DTO.Teacher;

public class TeacherDetailResponse
{
  public required Guid TeacherId { get; set; }
  public required SubjectResponse Subject { get; set; }
  public required decimal Credits { get; set; }
  public DateTimeOffset Created { get; set; }
}

namespace StudentCredits.Contracts.DTO.Student;

public class StudentResult
{
  public required StudentResponse Student { get; set; }
  public required IEnumerable<StudentDetailResponse> StudentDetails { get; set; }
}

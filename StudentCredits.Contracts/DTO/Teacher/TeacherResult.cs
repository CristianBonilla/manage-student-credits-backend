namespace StudentCredits.Contracts.DTO.Teacher;

public class TeacherResult
{
  public required TeacherResponse Teacher { get; set; }
  public required IEnumerable<TeacherDetailResponse> TeacherDetails { get; set; }
}

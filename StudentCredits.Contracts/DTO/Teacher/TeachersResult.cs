namespace StudentCredits.Contracts.DTO.Teacher;

public class TeachersResult
{
  public required TeacherResponse Teacher { get; set; }
  public required IEnumerable<TeacherDetailResponse> TeacherDetails { get; set; }
}

namespace StudentCredits.Contracts.DTO.Student;

public class StudentRequest
{
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
}

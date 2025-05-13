namespace StudentCredits.Contracts.DTO.Student;

public class StudentResponse
{
  public Guid StudentId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public DateTimeOffset Created { get; set; }
}

namespace StudentCredits.Contracts.DTO.Subject;

public class SubjectResponse
{
  public Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTimeOffset Created { get; set; }
}

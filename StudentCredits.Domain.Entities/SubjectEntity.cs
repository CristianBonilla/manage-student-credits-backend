namespace StudentCredits.Domain.Entities;

public class SubjectEntity
{
  public Guid SubjectId { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTimeOffset Created { get; set; }
  public uint Version { get; set; }
}

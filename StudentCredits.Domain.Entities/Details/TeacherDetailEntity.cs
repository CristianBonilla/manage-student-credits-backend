namespace StudentCredits.Domain.Entities.Details;

public class TeacherDetailEntity
{
  public Guid TeacherDetailId { get; set; }
  public required Guid TeacherId { get; set; }
  public required Guid SubjectId { get; set; }
  public required short Credits { get; set; }
  public DateTimeOffset Created { get; set; }
  public uint Version { get; set; }
  public TeacherEntity Teacher { get; set; } = null!;
  public SubjectEntity Subject { get; set; } = null!;
}

namespace StudentCredits.Domain.Entities.Details;

public class StudentDetailEntity
{
  public Guid StudentDetailId { get; set; }
  public required Guid TeacherDetailId { get; set; }
  public required Guid StudentId { get; set; }
  public DateTimeOffset Created { get; set; }
  public uint Version { get; set; }
  public TeacherDetailEntity TeacherDetail { get; set; } = null!;
  public StudentEntity Student { get; set; } = null!;
}

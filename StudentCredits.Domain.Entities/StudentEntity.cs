using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Domain.Entities;

public class StudentEntity
{
  public Guid StudentId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public DateTimeOffset Created { get; set; }
  public uint Version { get; set; }
  public ICollection<StudentDetailEntity> Details { get; set; } = [];
}

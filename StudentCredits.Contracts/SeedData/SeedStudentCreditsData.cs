using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Contracts.SeedData;

public class SeedStudentCreditsData
{
  public required SeedDataCollection<TeacherEntity> Teachers { get; set; }
  public required SeedDataCollection<StudentEntity> Students { get; set; }
  public required SeedDataCollection<TeacherDetailEntity> TeacherDetails { get; set; }
  public required SeedDataCollection<StudentDetailEntity> StudentDetails { get; set; }
  public required SeedDataCollection<SubjectEntity> Subjects { get; set; }
}

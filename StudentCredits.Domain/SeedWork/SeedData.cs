using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.SeedWork.Collections;

namespace StudentCredits.Domain.SeedWork;

public class SeedData : ISeedData
{
  public SeedStudentCreditsData StudentCredits => new()
  {
    Teachers = StudentCreditsCollection.Teachers,
    Students = StudentCreditsCollection.Students,
    TeacherDetails = StudentCreditsCollection.TeacherDetails,
    StudentDetails = StudentCreditsCollection.StudentDetails,
    Subjects = StudentCreditsCollection.Subjects
  };
}

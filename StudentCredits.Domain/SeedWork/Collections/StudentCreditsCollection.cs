using StudentCredits.Domain.SeedWork.Collections.StudentCredits.Details;
using StudentCredits.Domain.SeedWork.Collections.StudentCredits;

namespace StudentCredits.Domain.SeedWork.Collections;

class StudentCreditsCollection
{
  public static TeacherCollection Teachers => new();
  public static StudentCollection Students => new();
  public static TeacherDetailCollection TeacherDetails => new();
  public static StudentDetailCollection StudentDetails => new();
  public static SubjectCollection Subjects => new();
}

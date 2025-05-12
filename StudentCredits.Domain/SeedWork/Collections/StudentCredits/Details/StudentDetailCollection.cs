using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Domain.SeedWork.Collections.StudentCredits.Details;

class StudentDetailCollection : SeedDataCollection<StudentDetailEntity>
{
  static readonly TeacherDetailCollection _teacherDetails = StudentCreditsCollection.TeacherDetails;
  static readonly StudentCollection _students = StudentCreditsCollection.Students;
  protected override StudentDetailEntity[] Collection => [
    new StudentDetailEntity
    {
      StudentDetailId = new("{11ab0e13-3a0a-4fd7-9f80-3dc89b181efb}"),
      TeacherDetailId = _teacherDetails[0].TeacherDetailId,
      StudentId = _students[0].StudentId,
      Created = new DateTimeOffset(2024, 3, 2, 1, 0, 1, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{2096ecba-29db-49d6-9646-a6c3e424953f}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      StudentId = _students[0].StudentId,
      Created = new DateTimeOffset(2024, 3, 3, 2, 1, 2, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{eab71419-9084-4e72-9558-ce4d76f0fd30}"),
      TeacherDetailId = _teacherDetails[0].TeacherDetailId,
      StudentId = _students[1].StudentId,
      Created = new DateTimeOffset(2024, 3, 4, 3, 2, 3, TimeSpan.Zero)
    },
    new StudentDetailEntity
    {
      StudentDetailId = new("{90812e38-67ad-4207-8017-e2b09231231e}"),
      TeacherDetailId = _teacherDetails[1].TeacherDetailId,
      StudentId = _students[1].StudentId,
      Created = new DateTimeOffset(2024, 3, 2, 1, 0, 4, TimeSpan.Zero)
    }
  ];
}

using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Domain.SeedWork.Collections.StudentCredits.Details;

class TeacherDetailCollection : SeedDataCollection<TeacherDetailEntity>
{
  static readonly TeacherCollection _teachers = StudentCreditsCollection.Teachers;
  static readonly SubjectCollection _subjects = StudentCreditsCollection.Subjects;

  protected override TeacherDetailEntity[] Collection => [
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{f87b9e01-7066-4a18-bbe5-560a9c6ddec2}"),
      TeacherId = _teachers[0].TeacherId,
      SubjectId = _subjects[0].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 2, 1, 0, 1, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{f79f1e3c-8974-4b38-8f9d-72e738efb046}"),
      TeacherId = _teachers[0].TeacherId,
      SubjectId = _subjects[1].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 3, 2, 1, 2, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{d6e0c50c-e994-4d6b-aca0-ebc09b411aa0}"),
      TeacherId = _teachers[1].TeacherId,
      SubjectId = _subjects[2].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 4, 3, 2, 3, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{3b34bdd2-dc7c-41a1-bd79-dc8465aa2bf1}"),
      TeacherId = _teachers[1].TeacherId,
      SubjectId = _subjects[3].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 5, 4, 3, 4, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{cf98b2d3-7d9b-4ce1-996a-ed25c706b644}"),
      TeacherId = _teachers[2].TeacherId,
      SubjectId = _subjects[4].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 6, 5, 4, 5, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{ccc8bb25-685f-404b-b53d-d446686f9cec}"),
      TeacherId = _teachers[2].TeacherId,
      SubjectId = _subjects[5].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 7, 6, 5, 6, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{4f098579-1bd2-4e7c-822a-9160871450de}"),
      TeacherId = _teachers[3].TeacherId,
      SubjectId = _subjects[6].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 8, 7, 6, 7, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{a5794476-1317-4ebc-86b3-e9640b20a1a8}"),
      TeacherId = _teachers[3].TeacherId,
      SubjectId = _subjects[7].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 9, 8, 7, 8, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{7240162d-4f52-425d-a4f6-54b4127e8828}"),
      TeacherId = _teachers[4].TeacherId,
      SubjectId = _subjects[8].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 10, 9, 8, 9, TimeSpan.Zero)
    },
    new TeacherDetailEntity
    {
      TeacherDetailId = new("{10ed0335-ece3-4e80-9c01-28e1f1f3fe67}"),
      TeacherId = _teachers[4].TeacherId,
      SubjectId = _subjects[9].SubjectId,
      Credits = TeacherCommonValues.CREDITS,
      Created = new DateTimeOffset(2024, 2, 11, 11, 10, 10, TimeSpan.Zero)
    }
  ];
}

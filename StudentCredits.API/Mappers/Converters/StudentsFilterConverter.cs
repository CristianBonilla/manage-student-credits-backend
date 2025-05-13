using AutoMapper;
using StudentCredits.Domain.Entities.Details;
using StudentCredits.Domain.Entities;
using StudentCredits.Contracts.DTO.Student;

namespace StudentCredits.API.Mappers.Converters;

public class StudentsFilterConverter : ITypeConverter<
  IAsyncEnumerable<(StudentEntity Student, IEnumerable<StudentDetailEntity> StudentDetails)>,
  IAsyncEnumerable<StudentsResult>>
{
  public async IAsyncEnumerable<StudentsResult> Convert(
    IAsyncEnumerable<(StudentEntity Student, IEnumerable<StudentDetailEntity> StudentDetails)> source,
    IAsyncEnumerable<StudentsResult> destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;

    await foreach (var (student, studentDetails) in source)
    {
      yield return new()
      {
        Student = mapper.Map<StudentResponse>(student),
        StudentDetails = studentDetails.Select(mapper.Map<StudentDetailResponse>)
      };
    }
  }
}

using AutoMapper;
using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.API.Mappers.Converters;

public class TeachersFilterConverter : ITypeConverter<
  IAsyncEnumerable<(TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails)>,
  IAsyncEnumerable<TeachersResult>>
{
  public async IAsyncEnumerable<TeachersResult> Convert(
    IAsyncEnumerable<(TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails)> source,
    IAsyncEnumerable<TeachersResult> destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;

    await foreach (var (teacher, teacherDetails) in source)
    {
      yield return new()
      {
        Teacher = mapper.Map<TeacherResponse>(teacher),
        TeacherDetails = teacherDetails.Select(mapper.Map<TeacherDetailResponse>)
      };
    }
  }
}

using AutoMapper;
using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.API.Mappers.Converters;

public class TeacherResultConverter : ITypeConverter<
  (TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails),
  TeacherResult>
{
  public TeacherResult Convert(
    (TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails) source,
    TeacherResult destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;

    return new()
    {
      Teacher = mapper.Map<TeacherResponse>(source.Teacher),
      TeacherDetails = source.TeacherDetails.Select(mapper.Map<TeacherDetailResponse>)
    };
  }
}

using AutoMapper;
using StudentCredits.Domain.Entities.Details;
using StudentCredits.Domain.Entities;
using StudentCredits.Contracts.DTO.Student;

namespace StudentCredits.API.Mappers.Converters;

public class StudentResultConverter : ITypeConverter<
  (StudentEntity Student, IEnumerable<StudentDetailEntity> StudentDetails),
  StudentResult>
{
  public StudentResult Convert(
    (StudentEntity Student, IEnumerable<StudentDetailEntity> StudentDetails) source,
    StudentResult destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;

    return new()
    {
      Student = mapper.Map<StudentResponse>(source.Student),
      StudentDetails = source.StudentDetails.Select(mapper.Map<StudentDetailResponse>)
    };
  }
}

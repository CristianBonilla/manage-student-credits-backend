using AutoMapper;
using StudentCredits.API.Mappers.Converters;
using StudentCredits.Contracts.DTO.Student;
using StudentCredits.Contracts.DTO.Subject;
using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.API.Mappers;

class StudentCreditsProfile : Profile
{
  public StudentCreditsProfile()
  {
    TeacherMaps();
    StudentMaps();
    SubjectMaps();
  }

  private void TeacherMaps()
  {
    CreateMap<TeacherRequest, TeacherEntity>()
      .ForMember(member => member.TeacherId, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.TeacherDetails, options => options.Ignore());
    CreateMap<TeacherEntity, TeacherResponse>()
      .ReverseMap()
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.TeacherDetails, options => options.Ignore());
    CreateMap<TeacherDetailEntity, TeacherDetailResponse>()
      .ReverseMap()
      .ForMember(member => member.TeacherDetailId, options => options.Ignore())
      .ForMember(member => member.SubjectId, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.Teacher, options => options.Ignore());
    CreateMap<
      IAsyncEnumerable<(TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails)>,
      IAsyncEnumerable<TeachersResult>>()
      .ConvertUsing<TeachersFilterConverter>();
  }

  private void StudentMaps()
  {
    CreateMap<StudentRequest, StudentEntity>()
      .ForMember(member => member.StudentId, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.StudentDetails, options => options.Ignore());
    CreateMap<StudentEntity, StudentResponse>()
      .ReverseMap()
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.StudentDetails, options => options.Ignore());
    CreateMap<StudentDetailEntity, StudentDetailResponse>()
      .ReverseMap()
      .ForMember(member => member.StudentDetailId, options => options.Ignore())
      .ForMember(member => member.TeacherDetailId, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore())
      .ForMember(member => member.Student, options => options.Ignore());
    CreateMap<
      IAsyncEnumerable<(StudentEntity Student, IEnumerable<StudentDetailEntity> StudentDetails)>,
      IAsyncEnumerable<StudentsResult>>()
      .ConvertUsing<StudentsFilterConverter>();
  }

  private void SubjectMaps()
  {
    CreateMap<SubjectRequest, SubjectEntity>()
      .ForMember(member => member.SubjectId, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<SubjectEntity, SubjectResponse>()
      .ReverseMap()
      .ForMember(member => member.Version, options => options.Ignore());
  }
}

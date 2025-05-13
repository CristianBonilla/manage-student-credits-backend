using StudentCredits.Contracts.DTO.Teacher;
using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;
using StudentCredits.Helpers;
using StudentCredits.Helpers.Exceptions;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Domain.Services;

public class TeacherService(
  IStudentCreditsRepositoryContext context,
  ITeacherRepository teacherRepository,
  ITeacherDetailRepository teacherDetailRepository,
  ISubjectRepository subjectRepository) : ITeacherService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly ITeacherRepository _teacherRepository = teacherRepository;
  readonly ITeacherDetailRepository _teacherDetailRepository = teacherDetailRepository;
  readonly ISubjectRepository _subjectRepository = subjectRepository;

  public async Task<TeacherEntity> AddTeacher(TeacherEntity teacher)
  {
    CheckTeacher(teacher);
    TeacherEntity addedTeacher = _teacherRepository.Create(teacher);
    _ = await _context.SaveAsync();

    return addedTeacher;
  }

  public async Task<TeacherDetailEntity> AssignSubject(Guid teacherId, Guid subjectId, decimal credits = TeacherCommonValues.CREDITS)
  {
    TeacherEntity teacher = GetTeacherById(teacherId);
    SubjectEntity subject = GetSubjectById(subjectId);
    bool existingSubject = _teacherDetailRepository.Exists(teacherDetail => teacherDetail.TeacherId == teacherId && teacherDetail.SubjectId == subject.SubjectId);
    if (existingSubject)
      throw TeacherExceptionsHelper.BadRequest(teacher.TeacherId, subject.Name);
    TeacherDetailEntity teacherDetail = new()
    {
      TeacherId = teacherId,
      SubjectId = subjectId,
      Credits = credits
    };
    TeacherDetailEntity addedTeacherDetail = _teacherDetailRepository.Create(teacherDetail);
    _ = await _context.SaveAsync();

    return addedTeacherDetail;
  }

  public IAsyncEnumerable<(TeacherEntity Teacher, IEnumerable<TeacherDetailEntity> TeacherDetails)> GetTeachers()
  {
    var teacherDetails = _teacherDetailRepository.GetAll(null, teacherDetail => teacherDetail.Subject);
    var teachers = _teacherRepository
      .GetAll(teachers => teachers
        .OrderBy(order => order.DocumentNumber)
        .ThenBy(order => order.Firstname)
        .ThenBy(order => order.Lastname))
      .GroupJoin(
        teacherDetails,
        teacher => teacher.TeacherId,
        teacherDetail => teacherDetail.TeacherId,
        (teacher, teacherDetails) => (teacher, teacherDetails))
      .ToAsyncEnumerable();

    return teachers;
  }

  public IAsyncEnumerable<SubjectEntity> GetSubjectsByTeacherId(Guid teacherId)
  {
    var subjects = _teacherDetailRepository
      .GetByFilter(
        teacherDetail => teacherDetail.TeacherId == teacherId,
        teacherDetails => teacherDetails.OrderBy(order => order.Subject.Name),
        teacherDetail => teacherDetail.Subject)
      .Select(teacherDetail => teacherDetail.Subject)
      .ToAsyncEnumerable();

    return subjects;
  }

  public Task<TeacherEntity> FindTeacherById(Guid teacherId) => Task.FromResult(GetTeacherById(teacherId));

  private void CheckTeacher(TeacherEntity teacher)
  {
    bool existingTeacher = _teacherRepository.GetAll()
      .Any(currentTeacher => StringCommonHelper.IsEquivalent(currentTeacher.DocumentNumber, teacher.DocumentNumber) || StringCommonHelper.IsEquivalent(currentTeacher.Email, teacher.Email));
    if (existingTeacher)
      throw TeacherExceptionsHelper.BadRequest(teacher);
  }

  private TeacherEntity GetTeacherById(Guid teacherId)
  {
    TeacherEntity teacher = _teacherRepository.Find([teacherId]) ?? throw TeacherExceptionsHelper.NotFound(teacherId);

    return teacher;
  }

  private SubjectEntity GetSubjectById(Guid subjectId)
  {
    SubjectEntity subject = _subjectRepository.Find([subjectId]) ?? throw SubjectExceptionsHelper.NotFound(subjectId);

    return subject;
  }
}

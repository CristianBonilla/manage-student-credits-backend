using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;
using StudentCredits.Helpers.Exceptions;
using StudentCredits.Helpers;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;
using StudentCredits.Contracts.DTO.Student;

namespace StudentCredits.Domain.Services;

public class StudentService(
  IStudentCreditsRepositoryContext context,
  IStudentRepository studentRepository,
  IStudentDetailRepository studentDetailRepository,
  ITeacherDetailRepository teacherDetailRepository,
  ISubjectRepository subjectRepository) : IStudentService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly IStudentRepository _studentRepository = studentRepository;
  readonly IStudentDetailRepository _studentDetailRepository = studentDetailRepository;
  readonly ITeacherDetailRepository _teacherDetailRepository = teacherDetailRepository;
  readonly ISubjectRepository _subjectRepository = subjectRepository;

  public async Task<StudentEntity> AddStudent(StudentEntity student)
  {
    CheckStudent(student);
    StudentEntity addedStudent = _studentRepository.Create(student);
    _ = await _context.SaveAsync();

    return addedStudent;
  }

  public async Task<StudentDetailEntity> AssignSubject(Guid studentId, Guid teacherId, Guid subjectId)
  {
    SubjectEntity subject = GetSubjectById(subjectId);
    TeacherDetailEntity teacherDetail = GetTeacherDetail(teacherId, subjectId);
    bool existingStudentDetail = _studentDetailRepository.Exists(studentDetail => studentDetail.StudentId == studentId && studentDetail.TeacherDetailId == teacherDetail.TeacherDetailId);
    if (existingStudentDetail)
      throw StudentExceptionsHelper.BadRequest(studentId, subjectId);
    int subjectsNumber = _studentDetailRepository.GetByFilter(studentDetail => studentDetail.StudentId == studentId)
      .Select(studentDetail => _teacherDetailRepository.Find([studentDetail.TeacherDetailId])!)
      .DistinctBy(teacherDetail => teacherDetail.SubjectId)
      .Count();
    if (subjectsNumber == StudentCommonValues.SUBJECTS_MAX_NUMBER)
      throw StudentExceptionsHelper.BadRequest(studentId);
    StudentDetailEntity studentDetail = new()
    {
      StudentId = studentId,
      TeacherDetailId = teacherDetail.TeacherDetailId
    };
    StudentDetailEntity addedStudentDetail = _studentDetailRepository.Create(studentDetail);
    _ = await _context.SaveAsync();

    return addedStudentDetail;
  }

  public IAsyncEnumerable<(StudentEntity Student, IEnumerable<StudentDetailEntity> Details)> GetStudents()
  {
    var studentDetails = _studentDetailRepository.GetAll(null,
      studentDetail => studentDetail.TeacherDetail,
      studentDetail => studentDetail.TeacherDetail.Subject);
    var students = _studentRepository
      .GetAll(students => students
        .OrderBy(order => order.DocumentNumber)
        .ThenBy(order => order.Firstname)
        .ThenBy(order => order.Lastname))
      .GroupJoin(
        _studentDetailRepository.GetAll(),
        student => student.StudentId,
        studentDetail => studentDetail.StudentId,
        (student, studentDetails) => (student, studentDetails))
      .ToAsyncEnumerable();

    return students;
  }

  public IAsyncEnumerable<SubjectEntity> GetSubjectsByStudentId(Guid studentId)
  {
    var subjects = _studentDetailRepository
      .GetByFilter(
        studentDetail => studentDetail.StudentId == studentId,
        studentDetails => studentDetails.OrderBy(order => order.TeacherDetail.Subject.Name),
        studentDetail => studentDetail.TeacherDetail.Subject)
      .Select(studentDetail => studentDetail.TeacherDetail.Subject)
      .ToAsyncEnumerable();

    return subjects;
  }

  public Task<decimal> GetTotalCreditsByStudentId(Guid studentId)
  {
    decimal totalCredits = _studentDetailRepository.GetByFilter(studentDetail => studentDetail.StudentId == studentId)
      .Select(studentDetail => _teacherDetailRepository.Find([studentDetail.TeacherDetailId])!)
      .DistinctBy(teacherDetail => teacherDetail.SubjectId)
      .Sum(teacherDetail => teacherDetail.Credits);

    return Task.FromResult(totalCredits);
  }

  public Task<StudentEntity> FindStudentById(Guid studentId) => Task.FromResult(GetStudentById(studentId));

  private void CheckStudent(StudentEntity student)
  {
    bool existingStudent = _studentRepository.GetAll()
      .Any(currentStudent => StringCommonHelper.IsEquivalent(currentStudent.DocumentNumber, student.DocumentNumber) || StringCommonHelper.IsEquivalent(currentStudent.Email, student.Email));
    if (existingStudent)
      throw StudentExceptionsHelper.BadRequest(student);
  }

  private StudentEntity GetStudentById(Guid studentId)
  {
    StudentEntity student = _studentRepository.Find([studentId]) ?? throw StudentExceptionsHelper.NotFound(studentId);

    return student;
  }

  private SubjectEntity GetSubjectById(Guid subjectId)
  {
    SubjectEntity subject = _subjectRepository.Find([subjectId]) ?? throw SubjectExceptionsHelper.NotFound(subjectId);

    return subject;
  }

  private TeacherDetailEntity GetTeacherDetail(Guid teacherId, Guid subjectId)
  {
    TeacherDetailEntity teacherDetail = _teacherDetailRepository.Find(teacherDetail => teacherDetail.TeacherId == teacherId && teacherDetail.SubjectId == subjectId)
      ?? throw TeacherExceptionsHelper.NotFound(teacherId, subjectId);

    return teacherDetail;
  }
}

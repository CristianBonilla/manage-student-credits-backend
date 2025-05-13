using System.Net;
using StudentCredits.Contracts.Exceptions;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Helpers.Exceptions;

public class TeacherExceptionsHelper
{
  public static ServiceErrorException NotFound(Guid teacherId) => new(HttpStatusCode.NotFound, $"Teacher not found with identifier \"{teacherId}\"");
  public static ServiceErrorException NotFound(Guid teacherId, Guid subjectId) => new(HttpStatusCode.NotFound, $"Subject with identifier \"{subjectId}\" is not linked to the teacher with identifier \"{teacherId}\"");
  public static ServiceErrorException BadRequest(TeacherEntity teacher) => new(HttpStatusCode.BadRequest, $"Teacher already exists. Please verify the information provided: document number \"{teacher.DocumentNumber}\" and email \"{teacher.Email}\"");
  public static ServiceErrorException BadRequest(Guid teacherId, string subjectName) => new(HttpStatusCode.BadRequest, $"Subject \"{subjectName}\" is already linked to the teacher with identifier \"{teacherId}\"");
}

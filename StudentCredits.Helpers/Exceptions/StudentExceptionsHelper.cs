using System.Net;
using StudentCredits.Contracts.Exceptions;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Helpers.Exceptions;

public class StudentExceptionsHelper
{
  public static ServiceErrorException NotFound(Guid studentId) => new(HttpStatusCode.NotFound, $"Student not found with identifier \"{studentId}\"");
  public static ServiceErrorException BadRequest(StudentEntity student) => new(HttpStatusCode.BadRequest, $"Student already exists. Please verify the information provided: document number \"{student.DocumentNumber}\" and email \"{student.Email}\"");
  public static ServiceErrorException BadRequest(Guid studentId, Guid subjectId) => new(HttpStatusCode.BadRequest, $"Student with identifier \"{studentId}\" cannot have the subject \"{subjectId}\" with same teacher");
  public static ServiceErrorException BadRequest(Guid studentId) => new(HttpStatusCode.BadRequest, $"Student with identifier \"{studentId}\" can only have 3 subjects linked");
}

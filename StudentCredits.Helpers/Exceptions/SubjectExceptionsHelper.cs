using System.Net;
using StudentCredits.Contracts.Exceptions;

namespace StudentCredits.Helpers.Exceptions;

public class SubjectExceptionsHelper
{
  public static ServiceErrorException NotFound(Guid subjectId) => new(HttpStatusCode.NotFound, $"Subject not found with identifier \"{subjectId}\"");
  public static ServiceErrorException BadRequest(string subjectName) => new(HttpStatusCode.BadRequest, $"Subject already exists with name \"{subjectName}\"");
}

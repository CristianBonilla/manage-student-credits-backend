using System.Net;
using StudentCredits.Contracts.DTO;

namespace StudentCredits.Contracts.Exceptions;

public class ServiceErrorException(HttpStatusCode status, params string[] errors) : Exception(string.Join(", ", GetErrors(errors)))
{
  public ServiceError ServiceError { get; } = new(status, GetErrors(errors));

  private static string[] GetErrors(string[] errors) => [.. errors.Where(error => !string.IsNullOrWhiteSpace(error))];
}

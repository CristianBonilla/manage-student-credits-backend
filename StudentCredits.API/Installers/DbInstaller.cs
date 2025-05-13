using Microsoft.EntityFrameworkCore;
using StudentCredits.API.Utils;
using StudentCredits.Contracts.Enums;
using StudentCredits.Helpers;
using StudentCredits.Infrastructure.Contexts.StudentCredits;

namespace StudentCredits.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string connectionString = GetConnectionString(configuration);
    services.AddDbContextPool<StudentCreditsContext>(options => options.UseNpgsql(connectionString));
  }

  private static string GetConnectionString(IConfiguration configuration)
  {
    string connectionStringKey = ApiConfigKeys.GetConnectionKeyFromProcessType();
    string connectionString = configuration.GetConnectionString(connectionStringKey)
      ?? throw new InvalidOperationException($"Connection string \"{connectionStringKey}\" not established");
    if (ApiConfigKeys.ProcessType == ProcessTypes.Local)
      DirectoryConfigHelper.SetConnectionStringFullPathFromDataDirectory(ref connectionString);

    return connectionString;
  }
}

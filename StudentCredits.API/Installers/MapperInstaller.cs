using StudentCredits.API.Mappers;

namespace StudentCredits.API.Installers;

class MapperInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    services.AddAutoMapper(typeof(StudentCreditsProfile));
  }
}

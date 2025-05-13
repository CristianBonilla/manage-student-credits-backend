using Autofac.Extensions.DependencyInjection;
using StudentCredits.API.Utils;
using StudentCredits.Contracts.Enums;
using StudentCredits.Infrastructure.Contexts.StudentCredits;

namespace StudentCredits.API;

public class Program
{
  public static async Task Main(string[] args)
  {
    IHost host = CreateHostBuilder(args).Build();
    await DbConnectionSingleton.Start(host).Connect<StudentCreditsContext>(DbConnectionTypes.Migration);
    await host.RunAsync();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
      .ConfigureWebHostDefaults(builder =>
      {
        builder.UseStartup<Startup>();
      });
}

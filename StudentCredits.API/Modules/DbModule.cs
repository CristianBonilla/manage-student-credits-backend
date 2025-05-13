using Autofac;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.SeedWork;

namespace StudentCredits.API.Modules;

class DbModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<SeedData>()
      .As<ISeedData>()
      .InstancePerLifetimeScope();
  }
}

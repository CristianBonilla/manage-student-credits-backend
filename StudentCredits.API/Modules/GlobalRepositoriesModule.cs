using Autofac;
using StudentCredits.Contracts.Repository;
using StudentCredits.Infrastructure.Repositories;
using StudentCredits.Infrastructure.Repositories.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.API.Modules;

class GlobalRepositoriesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(RepositoryContext<>))
      .As(typeof(IRepositoryContext<>))
      .InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Repository<,>))
      .As(typeof(IRepository<,>))
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentCreditsRepositoryContext>()
      .As<IStudentCreditsRepositoryContext>()
      .InstancePerLifetimeScope();
  }
}

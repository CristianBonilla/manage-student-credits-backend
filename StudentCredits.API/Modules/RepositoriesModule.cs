using Autofac;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits;

namespace StudentCredits.API.Modules;

class RepositoriesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<SubjectRepository>()
      .As<ISubjectRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<TeacherRepository>()
      .As<ITeacherRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentRepository>()
      .As<IStudentRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<TeacherDetailRepository>()
      .As<ITeacherDetailRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentDetailRepository>()
      .As<IStudentDetailRepository>()
      .InstancePerLifetimeScope();
  }
}

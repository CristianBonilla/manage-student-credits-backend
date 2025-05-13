using Autofac;
using StudentCredits.Contracts.Services;
using StudentCredits.Domain.Services;

namespace StudentCredits.API.Modules;

public class StudentCreditsModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<TeacherService>()
      .As<ITeacherService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentService>()
      .As<IStudentService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<SubjectService>()
      .As<ISubjectService>()
      .InstancePerLifetimeScope();
  }
}

using Microsoft.EntityFrameworkCore;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Infrastructure.Contexts.StudentCredits.Config;
using StudentCredits.Infrastructure.Extensions;

namespace StudentCredits.Infrastructure.Contexts.StudentCredits;

public class StudentCreditsContext(DbContextOptions<StudentCreditsContext> options, ISeedData? seedData) : DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyEntityTypeConfig(seedData,
      typeof(SubjectConfig),
      typeof(TeacherConfig),
      typeof(StudentConfig),
      typeof(TeacherDetailConfig),
      typeof(StudentDetailConfig));
  }
}

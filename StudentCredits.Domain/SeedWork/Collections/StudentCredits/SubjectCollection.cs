using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Domain.SeedWork.Collections.StudentCredits;

class SubjectCollection : SeedDataCollection<SubjectEntity>
{
  protected override SubjectEntity[] Collection => [
    new SubjectEntity
    {
      SubjectId = new("{2ee9ebee-460c-4389-a50b-f0b602a2f617}"),
      Name = "Design Patterns",
      Description = "Learn to identify system problems with a general, reusable, scalable and applicable solution",
      Created = new DateTimeOffset(2024, 1, 11, 1, 0, 1, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{8a4b2308-49d0-44db-b2d5-675742d5f2fe}"),
      Name = "S.O.L.I.D Principles",
      Description = "Learn how to apply a set of rules and best practices for software development",
      Created = new DateTimeOffset(2024, 1, 15, 2, 1, 2, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{5a5f617c-4b9b-4974-9104-bd173b107172}"),
      Name = "Clean Architecture",
      Description = "Learn how clean architectures work to separate concerns into different, well-defined layers, with strict rules about how they should interact with each other",
      Created = new DateTimeOffset(2024, 1, 16, 3, 2, 3, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{eb8e2deb-9f48-4376-b5d0-9e5f898d6586}"),
      Name = "Microservices Architecture",
      Description = "Learn how to implement a design methodology for rapid deployment and updating of cloud-based applications",
      Created = new DateTimeOffset(2024, 1, 17, 4, 3, 4, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{e9a4cce8-57b0-4693-bf22-cfec292bccc5}"),
      Name = "QA Automation Fundamentals",
      Description = "Learn why QA Automation is so important in the software development cycle",
      Created = new DateTimeOffset(2024, 1, 18, 5, 4, 5, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{e2fd4b74-7b10-446e-821e-55717899c400}"),
      Name = "QA Automation Tools",
      Description = "Learn about the most popular tools for QA Automation, features and benefits",
      Created = new DateTimeOffset(2024, 1, 19, 6, 5, 6, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{4b2d9626-0259-42a5-a98c-11019b4cf873}"),
      Name = "Scrum Master Fundamentals",
      Description = "Discover how a Scrum Master can lead a team and keep members focused on the principles of the framework",
      Created = new DateTimeOffset(2024, 1, 20, 7, 6, 7, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{fc560c08-aa92-44c6-9ae1-101987824877}"),
      Name = "Planning a scrum master",
      Description = "Discover how a Scrum Master should expertly plan to maintain a fully agile team",
      Created = new DateTimeOffset(2024, 1, 21, 8, 7, 8, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{9748e5ff-07ba-4cb8-8617-53a785fc2ebf}"),
      Name = "Development With TypeScript",
      Description = "Learn how to become an expert with TypeScript the JavaScript superset for strict typing",
      Created = new DateTimeOffset(2024, 1, 22, 9, 8, 9, TimeSpan.Zero)
    },
    new SubjectEntity
    {
      SubjectId = new("{a3e42c74-8a68-4e2d-b339-caa2e89db0a7}"),
      Name = "Angular Fundamentals",
      Description = "Learn how to develop with one of the most popular and powerful frameworks, create robust applications",
      Created = new DateTimeOffset(2024, 1, 23, 10, 9, 10, TimeSpan.Zero)
    }
  ];
}

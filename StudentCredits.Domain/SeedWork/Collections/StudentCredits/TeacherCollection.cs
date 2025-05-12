using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Domain.SeedWork.Collections.StudentCredits;

class TeacherCollection : SeedDataCollection<TeacherEntity>
{
  protected override TeacherEntity[] Collection => [
    new TeacherEntity
    {
      TeacherId = new("{d3e5862d-3c30-4b35-8a0d-4632572aae47}"),
      DocumentNumber = "1023944678",
      Firstname = "Cristian Camilo",
      Lastname = "Bonilla",
      Email = "cristian10camilo95@gmail.com",
      Profession = "Senior Software Developer",
      Created = new DateTimeOffset(2024, 2, 1, 0, 1, 1, TimeSpan.Zero)
    },
    new TeacherEntity
    {
      TeacherId = new("{f41ed5f9-d853-4077-b6fe-9bb277bee93d}"),
      DocumentNumber = "1090012334",
      Firstname = "Fernando",
      Lastname = "Gutierrez",
      Email = "fernando.gutierrez@gmail.com",
      Profession = "Senior Software Architect",
      Created = new DateTimeOffset(2024, 2, 2, 1, 2, 2, TimeSpan.Zero)
    },
    new TeacherEntity
    {
      TeacherId = new("{08cd0782-93ba-4de3-b363-e7a4df2bfe7b}"),
      DocumentNumber = "1127789231",
      Firstname = "Ana Camila",
      Lastname = "Suarez",
      Email = "ana.suarez@outlook.com",
      Profession = "QA Automation",
      Created = new DateTimeOffset(2024, 2, 3, 2, 3, 3, TimeSpan.Zero)
    },
    new TeacherEntity
    {
      TeacherId = new("{42318f73-c7fd-4490-9594-7c72a77bbee7}"),
      DocumentNumber = "1643398122",
      Firstname = "Maria Natalia",
      Lastname = "Garcia",
      Email = "maria_natalia.garcia@outlook.com",
      Profession = "Scrum Master",
      Created = new DateTimeOffset(2024, 2, 4, 3, 4, 4, TimeSpan.Zero)
    },
    new TeacherEntity
    {
      TeacherId = new("{c774f591-750a-47f9-b283-327cdb62f627}"),
      DocumentNumber = "1992233120",
      Firstname = "Carlos Francisco",
      Lastname = "Herrera",
      Email = "carlos.herrera@gmail.com",
      Profession = "Senior Frontend Developer",
      Created = new DateTimeOffset(2024, 2, 5, 4, 5, 5, TimeSpan.Zero)
    }
  ];
}

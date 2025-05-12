using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Domain.SeedWork.Collections.StudentCredits;

class StudentCollection : SeedDataCollection<StudentEntity>
{
  protected override StudentEntity[] Collection => [
    new StudentEntity
    {
      StudentId = new("{ee466b07-1d3e-4356-8d03-0067d5ba30e5}"),
      DocumentNumber = "1033671288",
      Firstname = "Angela Natalia",
      Lastname = "Suarez",
      Email = "angela.suarez@outlook.com",
      Created = new DateTimeOffset(2024, 3, 1, 0, 1, 1, TimeSpan.Zero)
    },
    new StudentEntity
    {
      StudentId = new("{107e7e52-74fc-4589-b7d9-5f1ffc434637}"),
      DocumentNumber = "1109432112",
      Firstname = "Jeison Andrés",
      Lastname = "Bonilla",
      Email = "jeison.bonilla@gmail.com",
      Created = new DateTimeOffset(2024, 3, 3, 2, 2, 2, TimeSpan.Zero)
    }
  ];
}

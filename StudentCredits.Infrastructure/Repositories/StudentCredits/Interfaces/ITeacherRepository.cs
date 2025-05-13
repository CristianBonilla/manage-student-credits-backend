using StudentCredits.Contracts.Repository;
using StudentCredits.Domain.Entities;
using StudentCredits.Infrastructure.Contexts.StudentCredits;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

public interface ITeacherRepository : IRepository<StudentCreditsContext, TeacherEntity> { }

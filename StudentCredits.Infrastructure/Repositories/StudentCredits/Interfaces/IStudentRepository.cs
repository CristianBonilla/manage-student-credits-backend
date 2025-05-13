using StudentCredits.Contracts.Repository;
using StudentCredits.Domain.Entities;
using StudentCredits.Infrastructure.Contexts.StudentCredits;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

public interface IStudentRepository : IRepository<StudentCreditsContext, StudentEntity> { }

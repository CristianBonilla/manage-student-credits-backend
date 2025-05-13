using StudentCredits.Contracts.Repository;
using StudentCredits.Domain.Entities.Details;
using StudentCredits.Infrastructure.Contexts.StudentCredits;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;

public interface IStudentDetailRepository : IRepository<StudentCreditsContext, StudentDetailEntity> { }

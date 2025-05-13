using StudentCredits.Domain.Entities.Details;
using StudentCredits.Infrastructure.Contexts.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits.Details;

public class StudentDetailRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, StudentDetailEntity>(context), IStudentDetailRepository { }

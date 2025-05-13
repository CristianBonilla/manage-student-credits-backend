using StudentCredits.Domain.Entities.Details;
using StudentCredits.Infrastructure.Contexts.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Details.Interfaces;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits.Details;

public class TeacherDetailRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, TeacherDetailEntity>(context), ITeacherDetailRepository { }

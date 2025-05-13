using StudentCredits.Domain.Entities;
using StudentCredits.Infrastructure.Contexts.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits;

public class TeacherRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, TeacherEntity>(context), ITeacherRepository { }

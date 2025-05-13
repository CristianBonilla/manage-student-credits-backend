using StudentCredits.Domain.Entities;
using StudentCredits.Infrastructure.Contexts.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits;

public class SubjectRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, SubjectEntity>(context), ISubjectRepository { }

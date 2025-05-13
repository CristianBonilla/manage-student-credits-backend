using StudentCredits.Infrastructure.Contexts.StudentCredits;
using StudentCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace StudentCredits.Infrastructure.Repositories.StudentCredits;

public class StudentCreditsRepositoryContext(StudentCreditsContext context) : RepositoryContext<StudentCreditsContext>(context), IStudentCreditsRepositoryContext { }

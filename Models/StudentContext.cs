using Microsoft.EntityFrameworkCore;

namespace student_api;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {

    }
    public virtual DbSet<Student> Students { get; set; }
}

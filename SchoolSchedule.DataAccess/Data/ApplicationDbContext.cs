using Microsoft.EntityFrameworkCore;
using SchoolSchedule.DataAccess.Entities;

namespace SchoolSchedule.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
}

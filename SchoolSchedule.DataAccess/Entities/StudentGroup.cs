namespace SchoolSchedule.DataAccess.Entities;

public class StudentGroup
{
    public int Id { get; set; }
    public string GroupName { get; set; } = null!;
    public List<Schedule>? SchoolSchedules { get; set; }
    public List<Student>? Students { get;set; }
}
namespace SchoolSchedule.BusinessLogic.Dtos;

public class StudentDto
{
    public int Id { get; set; }
    public string StudentName { get; set; } = null!;
    public string StudentEmail { get; set; } = string.Empty;
    public string StudentPhoneNumber { get; set; } = null!;
    public int StudentGroupId { get; set; }
    public string StudentGroupName { get; set; } = null!;
}

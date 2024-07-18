namespace SchoolSchedule.BusinessLogic.Requests;

public class StudentRequest
{
    public required string StudentName { get; init; }
    public required string StudentEmail { get; init; }
    public required string StudentPhoneNumber { get; init; }
    public required string StudentGroupName { get; init; }
}

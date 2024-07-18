namespace SchoolSchedule.BusinessLogic.Requests;

public class ScheduleRequest
{
    public required string StudentGroupName { get; init; }
    public required DateTime Date { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime UpdatedDate { get; init; }
}

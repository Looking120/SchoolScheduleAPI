﻿namespace SchoolSchedule.DataAccess.Entities;

public class Schedule
{
    public int Id { get; set; }
    public int StudentGroupId { get; set; }
    public DateTime Date { get; set;}
    public TimeSpan StartTime { get; set;}
    public TimeSpan EndTime { get; set;}
    public StudentGroup? StudentGroup { get; set; }
}

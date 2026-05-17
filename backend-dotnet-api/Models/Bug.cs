public class Bug
{
    public int Id { get; set; } 
    public required string DisplayID { get; set; } //project name + number. ex: P1-001 (stands for project 1, bug number 1)
    public required string Title { get; set; }
    public required string Description { get; set; }
    public BugStatus Status { get; set; }
    public BugPriority Priority { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //timestamp
}

public enum BugStatus
{
    Open,
    InProgress,
    Fixed,
    Reopened,
    Closed
}

public enum BugPriority
{
    Low,
    Medium,
    High,
    Critical
}
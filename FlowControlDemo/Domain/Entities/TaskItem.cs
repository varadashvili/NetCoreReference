namespace FlowControlDemo.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool RemindMe { get; set; }

    public int? ReminderMinutesBeforeDue { get; set; }

    public List<string>? SubItems { get; set; }
}

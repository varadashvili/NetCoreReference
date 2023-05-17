namespace FluentValidationDemo.Models;

public class TaskItem
{
    public TaskItemDetails taskItemDetails { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool RemindMe { get; set; }

    public int? ReminderMinutesBeforeDue { get; set; }

    public List<string>? SubItems { get; set; }
}
namespace FlowControlDemo.Contracts.TaskItem;

public record AddTaskItemRequest(
    string Name,
    string Description,
    DateTime StartDate,
    DateTime DueDate,
    bool RemindMe,
    int? ReminderMinutesBeforeDue,
    List<string>? SubItems);

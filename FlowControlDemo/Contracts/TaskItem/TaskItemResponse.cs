namespace FlowControlDemo.Contracts.TaskItem;

public record TaskItemResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime DueDate,
    bool RemindMe,
    int? ReminderMinutesBeforeDue,
    List<string>? SubItems);
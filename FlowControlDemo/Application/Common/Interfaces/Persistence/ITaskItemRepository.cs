using FlowControlDemo.Domain.Entities;

namespace FlowControlDemo.Application.Common.Interfaces.Persistence;

public interface ITaskItemRepository
{
    TaskItem? GetTaskById(Guid id);

    TaskItem? GetTaskByName(string taskName);

    void Add(TaskItem taskItem);

    List<TaskItem> GetAll();

    void DeleteTaskById(Guid id);
}

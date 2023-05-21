using FlowControlDemo.Application.Common.Interfaces.Persistence;
using FlowControlDemo.Domain.Entities;

namespace FlowControlDemo.Infrastructure.Persistence;

public class TaskItemRepository : ITaskItemRepository
{
    private static readonly List<TaskItem> _taskItems = new List<TaskItem>();

    public void Add(TaskItem taskItem)
    {
        _taskItems.Add(taskItem);
    }

    public void DeleteTaskById(Guid id)
    {
        var task = _taskItems.SingleOrDefault(x => x.Id == id);

        if (task != null)
        {
            _taskItems.Remove(task);
        }
    }

    public List<TaskItem> GetAll()
    {
        return _taskItems;
    }

    public TaskItem? GetTaskById(Guid id)
    {
        return _taskItems.SingleOrDefault(x => x.Id == id);
    }

    public TaskItem? GetTaskByName(string taskName)
    {
        return _taskItems.SingleOrDefault(x => x.Name == taskName);
    }
}

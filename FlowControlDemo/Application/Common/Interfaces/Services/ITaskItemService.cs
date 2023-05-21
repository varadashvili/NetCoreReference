using ErrorOr;

using FlowControlDemo.Application.Dtos;
using FlowControlDemo.Contracts.TaskItem;

namespace FlowControlDemo.Application.Common.Interfaces.Services;

public interface ITaskItemService
{
    Task<ErrorOr<AddTaskItemResult>> Add(AddTaskItemRequest request);

    Task<ErrorOr<GetTaskItemsResult>> GetAll();

    Task<ErrorOr<GetTaskItemResult>> GetByName(string name);
}

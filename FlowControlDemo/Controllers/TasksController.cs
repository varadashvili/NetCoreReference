using FlowControlDemo.Application.Common.Interfaces.Services;
using FlowControlDemo.Application.Dtos;
using FlowControlDemo.Contracts.TaskItem;

using Microsoft.AspNetCore.Mvc;

namespace FlowControlDemo.Controllers;

[Route("api/[controller]")]
public class TasksController : ApiController
{
    private readonly ITaskItemService _taskItemService;

    public TasksController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }


    [HttpPost]
    public async Task<IActionResult> Post(AddTaskItemRequest request)
    {
        var result = await _taskItemService.Add(request);

        return result.Match(
            addTaskItemResult => Ok(new TaskItemResponse(
                addTaskItemResult.TaskItem.Id,
                addTaskItemResult.TaskItem.Name,
                addTaskItemResult.TaskItem.Description,
                addTaskItemResult.TaskItem.StartDate,
                addTaskItemResult.TaskItem.DueDate,
                addTaskItemResult.TaskItem.RemindMe,
                addTaskItemResult.TaskItem.ReminderMinutesBeforeDue,
                addTaskItemResult.TaskItem.SubItems)),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taskItemService.GetAll();

        return result.Match(
            getTaskItemsResult => Ok(getResponseFromTaskItemsResult(getTaskItemsResult)),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("ByName")]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await _taskItemService.GetByName(name);

        return result.Match(
            getTaskItemResult => Ok(new TaskItemResponse(
                getTaskItemResult.TaskItem.Id,
                getTaskItemResult.TaskItem.Name,
                getTaskItemResult.TaskItem.Description,
                getTaskItemResult.TaskItem.StartDate,
                getTaskItemResult.TaskItem.DueDate,
                getTaskItemResult.TaskItem.RemindMe,
                getTaskItemResult.TaskItem.ReminderMinutesBeforeDue,
                getTaskItemResult.TaskItem.SubItems)),
            errors => Problem(errors));
    }

    private List<TaskItemResponse> getResponseFromTaskItemsResult(GetTaskItemsResult getTaskItemsResult)
    {
        List<TaskItemResponse> result = new List<TaskItemResponse>();

        foreach (var taskItem in getTaskItemsResult.TaskItems)
        {
            result.Add(new TaskItemResponse(
                taskItem.Id,
                taskItem.Name,
                taskItem.Description,
                taskItem.StartDate,
                taskItem.DueDate,
                taskItem.RemindMe,
                taskItem.ReminderMinutesBeforeDue,
                taskItem.SubItems));
        }

        return result;
    }
}

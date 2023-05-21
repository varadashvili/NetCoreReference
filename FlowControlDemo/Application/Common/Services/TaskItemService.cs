using ErrorOr;

using FlowControlDemo.Application.Common.Interfaces.Persistence;
using FlowControlDemo.Application.Common.Interfaces.Services;
using FlowControlDemo.Application.Dtos;
using FlowControlDemo.Contracts.TaskItem;
using FlowControlDemo.Domain.Common.Errors;
using FlowControlDemo.Domain.Entities;

using FluentValidation;

namespace FlowControlDemo.Application.Common.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IValidator<AddTaskItemRequest> _validator;

    public TaskItemService(ITaskItemRepository taskItemRepository, IValidator<AddTaskItemRequest> validator)
    {
        this._taskItemRepository = taskItemRepository;
        this._validator = validator;
    }

    public async Task<ErrorOr<AddTaskItemResult>> Add(AddTaskItemRequest request)
    {
        try
        {
            await Task.CompletedTask;

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .ConvertAll(validationFailure => Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));

                return errors;
            }

            var task = _taskItemRepository.GetTaskByName(request.Name);
            if (task is not null)
            {
                return Errors.TaskItem.DuplicateName;
            }

            task = new TaskItem
            {
                Name = request.Name,
                Description = request.Description,
                DueDate = request.DueDate,
                ReminderMinutesBeforeDue = request.ReminderMinutesBeforeDue,
                RemindMe = request.RemindMe,
                StartDate = request.StartDate,
                SubItems = request.SubItems
            };

            _taskItemRepository.Add(task);

            var result = new AddTaskItemResult(task);

            return result;
        }
        catch (Exception ex)
        {
            var message = ex.Message;

            return Error.Failure();
        }
    }

    public async Task<ErrorOr<GetTaskItemsResult>> GetAll()
    {
        try
        {
            await Task.CompletedTask;

            var tasks = _taskItemRepository.GetAll();

            var result = new GetTaskItemsResult(tasks);

            return result;
        }
        catch (Exception ex)
        {
            var message = ex.Message;

            return Error.Failure();
        }
    }

    public async Task<ErrorOr<GetTaskItemResult>> GetByName(string name)
    {
        try
        {
            await Task.CompletedTask;

            var task = _taskItemRepository.GetTaskByName(name);

            if (task is null)
            {
                return Error.NotFound();
            }

            var result = new GetTaskItemResult(task);

            return result;
        }
        catch (Exception ex)
        {
            var message = ex.Message;

            return Error.Failure();
        }
    }
}

using FlowControlDemo.Domain.Entities;

namespace FlowControlDemo.Application.Dtos;

public record GetTaskItemsResult(List<TaskItem> TaskItems);
using FlowControlDemo.Application.Common.Interfaces.Services;
using FlowControlDemo.Contracts.TaskItem;

using FluentValidation;

namespace FlowControlDemo.Application.Common.Validations;

public class TaskItemRequestValidator : AbstractValidator<AddTaskItemRequest>
{
    public TaskItemRequestValidator(IDateTimeProvider dateTimeProvider)
    {
        RuleFor(t => t.Description)
            .NotEmpty()
            .Length(5, 100)
            .WithMessage("Length ({TotalLength}) of {PropertyName} is invalid");

        RuleFor(t => t.Name)
            .NotEmpty()
            .Length(5, 50);

        RuleFor(t => t.DueDate)
            .GreaterThanOrEqualTo(dateTimeProvider.UtcNow)
            //.Must(x => x > dateTimeProvider.UtcNow)
            .WithMessage("{PropertyName} must be in the future");

        RuleFor(t => t.DueDate)
            .GreaterThan(t => t.StartDate);

        When(t => t.RemindMe == true, () =>
        {
            RuleFor(t => t.ReminderMinutesBeforeDue)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("ReminderMinutesBeforeDue must be set")
                .GreaterThan(0)
                .WithMessage("ReminderMinutesBeforeDue must be greater than 0")
                .Must(value => value % 15 == 0)
                .WithMessage("ReminderMinutesBeforeDue must be a multiple of 15");
        });

        RuleForEach(t => t.SubItems)
            .NotEmpty()
            .WithMessage("values in the SubItems array cannot be empty")
            .Length(2, 10);
    }
}
using CustomFluentValidation.Common.Validations.CustomValidators;
using CustomFluentValidation.Models;
using CustomFluentValidation.Services.DateTimeProvider;

using FluentValidation;

namespace CustomFluentValidation.Common.Validations;

public class TaskItemValidator : AbstractValidator<TaskItem>
{
    public TaskItemValidator(IDateTimeProvider dateTimeProvider)
    {
        RuleFor(t => t.DueDate)
            .GreaterThanOrEqualTo(dateTimeProvider.UtcNow)
            //.Must(x => x > dateTimeProvider.UtcNow)
            .WithMessage("{PropertyName} must be in the future");

        RuleFor(t => t.StartDate)
            .AfterSunrise(dateTimeProvider);

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

        RuleFor(t => t.taskItemDetails)
            .SetValidator(new TaskItemDetailsValidator());
    }
}

using FluentValidation;

using FluentValidationDemo.Models;

namespace FluentValidationDemo.Common.Validations;

public class TaskItemDetailsValidator : AbstractValidator<TaskItemDetails>
{
    public TaskItemDetailsValidator()
    {
        RuleFor(t => t.Description)
            .NotEmpty()
            .Length(5, 100)
            .WithMessage("Length ({TotalLength}) of {PropertyName} is invalid");

        RuleFor(t => t.Name)
            .NotEmpty()
            .Length(5, 50);
    }
}

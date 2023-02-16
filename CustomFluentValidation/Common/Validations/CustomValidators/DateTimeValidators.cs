using CustomFluentValidation.Services.DateTimeProvider;

using FluentValidation;

namespace CustomFluentValidation.Common.Validations.CustomValidators;

public static class DateTimeValidators
{
    public static IRuleBuilderOptions<T, DateTime> AfterSunrise<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder, IDateTimeProvider dateTimeProvider)
    {
        var sunrise = dateTimeProvider.MidNight.AddHours(6);

        return ruleBuilder
            .Must((objectRoot, dateTime, context) =>
            {
                var providedTime = TimeOnly.FromDateTime(dateTime);

                context.MessageFormatter.AppendArgument("Sunrise", sunrise);
                context.MessageFormatter.AppendArgument("ProvidedTime", providedTime);

                return providedTime > sunrise;
            })
            .WithMessage("{PropertyName} time must be after {Sunrise}. You provided {ProvidedTime}");
    }
}

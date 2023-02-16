namespace CustomFluentValidation.Services.DateTimeProvider;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    TimeOnly MidNight { get; }
}

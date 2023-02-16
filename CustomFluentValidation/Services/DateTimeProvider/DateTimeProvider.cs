namespace CustomFluentValidation.Services.DateTimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public TimeOnly MidNight => TimeOnly.MinValue;
}

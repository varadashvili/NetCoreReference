using FlowControlDemo.Application.Common.Interfaces.Services;

namespace FlowControlDemo.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

using buberDinner.Application.Common.Interfaces.Services;

namespace buberDinner.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
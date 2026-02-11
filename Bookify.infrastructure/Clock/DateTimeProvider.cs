using Bookify.Application.Abstractions.Clock;

namespace Bookify.infrastructure.Clock;

internal sealed class DateTimeProvider:IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
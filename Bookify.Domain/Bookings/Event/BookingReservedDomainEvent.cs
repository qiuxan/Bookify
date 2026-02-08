using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event;

public sealed record BookingReservedDomainEvent(Guid BookingID):IDomainEvent;
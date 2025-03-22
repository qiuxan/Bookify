﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Booking.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
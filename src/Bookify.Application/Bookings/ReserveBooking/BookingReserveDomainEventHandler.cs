using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Booking;
using Bookify.Domain.Booking.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingReserveDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReserveDomainEventHandler(
        IBookingRepository bookingRepository, 
        IUserRepository userRepository, 
        IEmailService emailService
        )
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new InvalidOperationException("Booking not found.");
        }

        var user = await _userRepository.GetById(booking.UserId, cancellationToken);

        if (user is null)
        {
            throw new InvalidOperationException("User not found.");
        }

        await _emailService.SendEmailAsync(
            user.Email,
            "Booking Reserved",
            $"Your booking with id {booking.Id} has been reserved. You have 10 mins to confirm this booking");
    }
}
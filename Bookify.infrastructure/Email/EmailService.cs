using Bookify.Application.Abstractions.Email;

namespace Bookify.infrastructure.Email;

internal sealed class EmailService:IEmailService
{
    public Task SendAsync(Domain.Users.Email email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
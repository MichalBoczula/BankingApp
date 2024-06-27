using MediatR;

namespace Banking.Application.Features.Commands.Emails.DeleteEmail
{
    internal record DeleteEmailCommand : IRequest<bool>
    {
        public required int EmailId { get; init; }
    }
}

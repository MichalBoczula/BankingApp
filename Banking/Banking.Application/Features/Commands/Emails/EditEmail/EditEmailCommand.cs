using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.EditEmail
{
    internal record EditEmailCommand : IRequest<bool>
    {
        public required UpdatedEmailExternal Contract { get; init; }
        public required int EmailId{ get; init; }
    }
}

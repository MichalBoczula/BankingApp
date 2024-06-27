using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.AddEmail
{
    internal record AddEmailCommand : IRequest<int>
    {
        public required CreatedEmailExternal Contract { get; init; }
    }
}

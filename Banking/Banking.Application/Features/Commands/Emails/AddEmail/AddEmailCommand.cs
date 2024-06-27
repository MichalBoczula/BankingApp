using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.AddEmail
{
    internal class AddEmailCommand : IRequest<int>
    {
        public CreatedEmailExternal Contract { get; set; }
    }
}

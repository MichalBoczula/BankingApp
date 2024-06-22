using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.Emails
{
    internal class GetEmailByIdQuery : IRequest<EmailDto>
    {
        public int EmailId { get; set; }
    }
}

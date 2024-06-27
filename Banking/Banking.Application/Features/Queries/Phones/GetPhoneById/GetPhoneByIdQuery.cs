using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.Phones.GetPhoneById
{
    internal class GetPhoneByIdQuery : IRequest<PhoneDto>
    {
        public int PhoneId { get; set; }
    }
}

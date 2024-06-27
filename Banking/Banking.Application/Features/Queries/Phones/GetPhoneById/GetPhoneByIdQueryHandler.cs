using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.Phones.GetPhoneById
{
    internal class GetPhoneByIdQueryHandler : IRequestHandler<GetPhoneByIdQuery, PhoneDto>
    {
        private readonly IQueriesPhoneDataRepository _queriesPhonesDataRepository;

        public GetPhoneByIdQueryHandler(IQueriesPhoneDataRepository queriesPhonesDataRepository)
        {
            _queriesPhonesDataRepository = queriesPhonesDataRepository;
        }

        public async Task<PhoneDto> Handle(GetPhoneByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queriesPhonesDataRepository.GetPhoneById(request.PhoneId);
            return result;
        }
    }
}

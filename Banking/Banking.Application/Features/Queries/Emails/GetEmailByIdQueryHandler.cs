using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.Emails
{
    internal class GetEmailByIdQueryHandler : IRequestHandler<GetEmailByIdQuery, EmailDto>
    {
        public IQueriesEmailDataRepository _queriesEmailsDataRepository { get; set; }

        public GetEmailByIdQueryHandler(IQueriesEmailDataRepository queriesEmailsDataRepository)
        {
            this._queriesEmailsDataRepository = queriesEmailsDataRepository;
        }

        public async Task<EmailDto> Handle(GetEmailByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queriesEmailsDataRepository.GetEmailById(request.EmailId);
            return result;
        }
    }
}

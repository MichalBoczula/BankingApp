using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.AddEmail
{
    internal record AddEmailCommandHandler : IRequestHandler<AddEmailCommand, int>
    {
        private readonly ICommandsEmailDataRepository _commandsEmailDataRepository;

        public AddEmailCommandHandler(ICommandsEmailDataRepository commandsEmailDataRepository)
        {
            _commandsEmailDataRepository = commandsEmailDataRepository;
        }

        public async Task<int> Handle(AddEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _commandsEmailDataRepository.AddEmail(request.Contract, cancellationToken);
            return result;
        }
    }
}

using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.EditEmail
{
    internal record EditEmailCommandHandler : IRequestHandler<EditEmailCommand, bool>
    {
        private readonly ICommandsEmailDataRepository _commandsEmailDataRepository;

        public EditEmailCommandHandler(ICommandsEmailDataRepository commandsEmailDataRepository)
        {
            _commandsEmailDataRepository = commandsEmailDataRepository;
        }

        public async Task<bool> Handle(EditEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _commandsEmailDataRepository.EditEmail(request.Contract, request.EmailId, cancellationToken);
            return result;
        }
    }
}
 
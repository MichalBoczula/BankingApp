using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Emails.DeleteEmail
{
    internal class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand, bool>
    {
        private readonly ICommandsEmailDataRepository _commandsEmailDataRepository;

        public DeleteEmailCommandHandler(ICommandsEmailDataRepository commandsEmailDataRepository)
        {
            _commandsEmailDataRepository = commandsEmailDataRepository;
        }

        public async Task<bool> Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _commandsEmailDataRepository.DeleteEmail(request.EmailId, cancellationToken);
            return result;
        }
    }
}

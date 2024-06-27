using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.DeleteAddress
{
    internal record DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly ICommandsAddressDataRepository _commandsAddressDataRepository;

        public DeleteAddressCommandHandler(ICommandsAddressDataRepository commandsAddressDataRepository)
        {
            _commandsAddressDataRepository = commandsAddressDataRepository;
        }

        public Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var result = _commandsAddressDataRepository.DeleteAddress(request.AddressId, cancellationToken);
            return result;
        }
    }
}

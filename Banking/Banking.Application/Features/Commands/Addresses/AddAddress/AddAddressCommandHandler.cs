using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.AddAddress
{
    internal record AddAddressCommandHandler : IRequestHandler<AddAddressCommand, int>
    {
        private readonly ICommandsAddressDataRepository _commandsAddressDataRepository;

        public AddAddressCommandHandler(ICommandsAddressDataRepository commandsAddressDataRepository)
        {
            _commandsAddressDataRepository = commandsAddressDataRepository;
        }

        public async Task<int> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _commandsAddressDataRepository.AddAddress(request.Contract, cancellationToken);
            return result;
        }
    }
}

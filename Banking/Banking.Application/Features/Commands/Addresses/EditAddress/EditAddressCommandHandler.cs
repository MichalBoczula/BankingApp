using Banking.Persistance.Repositories.Commands.Abstract;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.EditAddress
{
    internal class EditAddressCommandHandler : IRequestHandler<EditAddressCommand, bool>
    {
        private readonly ICommandsAddressDataRepository _commandsAddressDataRepository;

        public EditAddressCommandHandler(ICommandsAddressDataRepository commandsAddressDataRepository)
        {
            this._commandsAddressDataRepository = commandsAddressDataRepository;
        }

        public async Task<bool> Handle(EditAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _commandsAddressDataRepository.EditAddress(request.Contract, request.AddressId, cancellationToken);
            return result;
        }
    }
}

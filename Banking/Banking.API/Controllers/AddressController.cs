using Banking.Application.Features.Commands.Addresses.AddAddress;
using Banking.Application.Features.Queries.Addresses;
using BankingApp.DataTransferObject.Externals;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{addressId}")]
        public async Task<ActionResult<CustomerAccountDataDto>> GetAddressById(int addressId)
        {
            var result = await _mediator.Send(new GetAddressByIdQuery { AddressId = addressId });
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<CustomerAccountDataDto>> AddAddress(AddressExternal address)
        {
            var result = await _mediator.Send(new AddAddressCommand { Contract = address });
            return Ok(result);
        }
    }
}

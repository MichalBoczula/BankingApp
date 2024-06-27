using Banking.Application.Features.Commands.Addresses.AddAddress;
using Banking.Application.Features.Commands.Addresses.DeleteAddress;
using Banking.Application.Features.Commands.Addresses.EditAddress;
using Banking.Application.Features.Queries.Addresses.GetAddressById;
using BankingApp.DataTransferObject.Externals;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
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
        public async Task<ActionResult<AddressDto>> GetAddressById(int addressId)
        {
            var result = await _mediator.Send(new GetAddressByIdQuery { AddressId = addressId });
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<int>> AddAddress([FromBody] CreatedAddressExternal address)
        {
            var result = await _mediator.Send(new AddAddressCommand { Contract = address });
            return Ok(result);
        }

        [HttpPut("{addressId}")]
        public async Task<ActionResult<bool>> EditAddress(int addressId, [FromBody] UpdatedAddressExternal address)
        {
            var result = await _mediator.Send(new EditAddressCommand { Contract = address, AddressId = addressId });
            return Ok(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<ActionResult<bool>> DeleteAddress(int addressId)
        {
            var result = await _mediator.Send(new DeleteAddressCommand { AddressId = addressId });
            return Ok(result);
        }
    }
}

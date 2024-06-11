using Banking.Application.Features.Queries.GetCustomerAccountDataById;
using BankingApp.DataTransferObject.Internals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerAccountDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerAccountDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerNumber}")]
        public async Task<ActionResult<CustomerAccountDataDto>> GetCustomerAccountDataById(Guid customerNumber)
        {
            var result = await _mediator.Send(new GetCustomerAccountDataByIdQuery { CustomerNumber = customerNumber });
            return Ok(result);
        }
    }
}

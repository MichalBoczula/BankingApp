using Banking.Application.Features.Queries.CustomerData.GetCustomerAccountDataById;
using Banking.Application.Features.Queries.CustomerData.GetCustomerPersonalDataById;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CustomerAccounts/{customerNumber}")]
        public async Task<ActionResult<CustomerAccountDataDto>> GetCustomerAccountDataById(Guid customerNumber)
        {
            var result = await _mediator.Send(new GetCustomerAccountDataByIdQuery { CustomerNumber = customerNumber });
            return Ok(result);
        }

        [HttpGet("CustomerPersonalData/{customerNumber}")]
        public async Task<ActionResult<CustomerAccountDataDto>> GetCustomerPersonalDataById(Guid customerNumber)
        {
            var result = await _mediator.Send(new GetCustomerPersonalDataByIdQuery { CustomerNumber = customerNumber });
            return Ok(result);
        }
    }
}

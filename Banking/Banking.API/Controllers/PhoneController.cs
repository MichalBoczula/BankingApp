using Banking.Application.Features.Queries.Phones.GetPhoneById;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{phoneId}")]
        public async Task<ActionResult<PhoneDto>> GetPhoneById(int phoneId)
        {
            var result = await _mediator.Send(new GetPhoneByIdQuery { PhoneId = phoneId });
            return Ok(result);
        }
    }
}

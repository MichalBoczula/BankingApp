using Banking.Application.Features.Queries.Addresses;
using Banking.Application.Features.Queries.Emails;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{emailId}")]
        public async Task<ActionResult<EmailDto>> GetEmailById(int emailId)
        {
            var result = await _mediator.Send(new GetEmailByIdQuery { EmailId = emailId });
            return Ok(result);
        }
    }
}

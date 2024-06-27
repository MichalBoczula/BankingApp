using Banking.Application.Features.Commands.Emails.AddEmail;
using Banking.Application.Features.Queries.Emails.GetEmailById;
using BankingApp.DataTransferObject.Externals;
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

        [HttpPost]
        public async Task<ActionResult<int>> AddEmail([FromBody] CreatedEmailExternal email)
        {
            var result = await _mediator.Send(new AddEmailCommand { Contract = email });
            return Ok(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Api.Base;
using Theater.CQRS.User.Command;
using Theater.CQRS.User.Query;
using dom = Theater.Domain.User;

namespace Theater.Api.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController<LoginController>
    {
        public LoginController(IMediator mediator, ILogger<LoginController> logger) 
            : base(mediator, logger) { }

        [HttpPost]
        public async Task<ActionResult<dom.Login>> CreateLoginAsync(dom.Login login)
        {
            try
            {
                return await this.mediator.Send(new CreateLoginCommand
                {
                    Item = login
                });
            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dom.Login>> GetLoginByIdAsync(string id)
        {
            try
            {
                return await this.mediator.Send(new GetLoginById
                {
                    Id = id
                });
            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }
    }
}

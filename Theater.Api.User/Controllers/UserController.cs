using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Api.Base;
using Theater.CQRS.User.Query;
using DOM = Theater.Domain.User;

namespace Theater.Api.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserController>
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger) { }


        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<DOM.User>> GetUserByUserNameAsync(string username, string password)
        {
            try
            {
                return await this.mediator.Send(new GetUserByUserName
                {
                    UserName = username,
                    Password = password
                });
            }
            catch(Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }
    }
}

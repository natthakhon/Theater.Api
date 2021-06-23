using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Api.Base;
using Theater.Repository.User;
using dom = Theater.Domain.User;

namespace Theater.Api.Movie.Controllers
{
    [Route("api/movie/[controller]")]
    [ApiController]
    public class LoginController : BaseController<LoginController>
    {
        ILoginRepository loginRepository;
        public LoginController(IMediator mediator
            , ILogger<LoginController> logger
            , ILoginRepository loginRepository) : base(mediator, logger)
        {
            this.loginRepository = loginRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dom.Login>> GetLoginByIdAsync(string id)
        {
            try
            {
                return await this.loginRepository.GetLoginById(id);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }
    }
}

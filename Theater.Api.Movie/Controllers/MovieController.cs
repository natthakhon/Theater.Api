using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Api.Base;
using Theater.CQRS.Movie.Command;
using DOM = Theater.Domain.Movie;

namespace Theater.Api.Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController<MovieController>
    {
        public MovieController(IMediator mediator, ILogger<MovieController> logger) : base(mediator, logger) { }

        [HttpPost]
        public async Task<ActionResult<DOM.Movie>> CreateMovieAsync(DOM.Movie movie)
        {
            try
            {
                return await this.mediator.Send(new CreateMovieCommand
                {
                    Item = movie
                }); ;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{theater}")]
        public async Task<ActionResult<DOM.Theater>> CreateTheaterAsync(DOM.Theater theater)
        {
            try
            {
                return await this.mediator.Send(new CreateTheaterCommand
                {
                    Item = theater
                }); ;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.ToString());
                return BadRequest(e.Message);
            }
        }

    }
}

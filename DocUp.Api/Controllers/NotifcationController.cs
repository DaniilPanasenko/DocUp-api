using System;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/notifications")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class NotficatonController : ControllerBase
    {
        private readonly IMapper _mapper;

        public NotficatonController(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("all")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> GetAll([FromQuery]int count)
        {
            throw new NotImplementedException();
        }

        [HttpGet("my/{accountId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> GetMyNotifications(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}

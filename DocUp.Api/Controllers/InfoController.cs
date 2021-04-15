using System;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/info")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class InfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIlnessService _ilnessService;

        public InfoController(
            IMapper mapper,
            IIlnessService ilnessService)
        {
            _ilnessService = ilnessService;
            _mapper = mapper;
        }


        [HttpGet("ilness_list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetIlnessListAsync()
        {
            var ilnesses = await _ilnessService.GetIlnessListAsync();
            return Ok(ilnesses.Select(x => new { Id = x.Id, Name = x.Name }));
        }

    }
}

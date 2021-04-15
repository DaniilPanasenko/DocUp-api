using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/device")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class DeviceController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DeviceController(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("data")]
        public async Task<ActionResult> SendDataAsync()//TODO:Device data
        {
            throw new NotImplementedException();
        }
    }
}
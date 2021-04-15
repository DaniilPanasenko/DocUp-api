using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/patient/{patientId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PatientController(
            IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("info")]
        public async Task<ActionResult> GetInfoAsync(string clinicId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("info")]
        public async Task<ActionResult> UpdateClinicInfoAsync()//TODO:ClinicDto
        {
            throw new NotImplementedException();
        }

        [HttpPost("device")]
        public async Task<ActionResult> AddDeviceAsync()
        {
            throw new NotImplementedException();
        }
    }
}

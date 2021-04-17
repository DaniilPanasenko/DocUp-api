using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using DocUp.Api.Contracts.Dtos;
using DocUp.Api.Contracts.ViewModels;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/patient")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Authorize(Roles = Roles.Patient)]
    public class PatientController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IIlnessService _ilnessService;
        private readonly IDeviceService _deviceService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;

        public PatientController(
            IAccountService accountService,
            IIlnessService ilnessService,
            IDeviceService deviceService,
            IMapper mapper,
            IApplicationUser applicationUser,
            IPatientService patientService)
        {
            _accountService = accountService;
            _ilnessService = ilnessService;
            _deviceService = deviceService;
            _mapper = mapper;
            _applicationUser = applicationUser;
            _patientService = patientService;
        }

        private int UserId => _accountService.GetUserIdByAccountIdAsync(_applicationUser.Id, _applicationUser.Role).Result;

        [HttpGet("info")]
        [ProducesResponseType(typeof(PatientVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetInfoAsync()
        {
            var result = await _patientService.GetInfoAsync(UserId);

            if (result.Code == ResultCode.NotFound)
            {
                return NotFound();
            }

            var info = _mapper.Map<PatientModel, PatientVm>(result.Value);
            return Ok(info);
        }

        [HttpPut("info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateInfoAsync(PatientDto patient)
        {
            var model = _mapper.Map<PatientDto, PatientModel>(patient);
            model.Id = UserId;

            var result = await _patientService.UpdateAsync(model);
            return StatusCode((int)result);
        }

        [HttpPost("device/{seria}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddDeviceAsync(int seria)
        {
            var result = await _deviceService.ConnectToUserAsync(UserId, seria);

            if (result == ResultCode.NotFound) return NotFound();
            if (result == ResultCode.Success) return Ok();
            else return Conflict((int)result);
        }

        [HttpPost("ilness/{ilnessId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddIlnessAsync(int ilnessId)
        {
            var result = await _patientService.AddIlnessAsync(UserId, ilnessId);

            if (result == ResultCode.NotFound) return NotFound();
            if (result == ResultCode.Success) return Ok();
            else return Conflict((int)result);
        }
    }
}

using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Api.Auth;
using DocUp.Api.Contracts.Dtos;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocUp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/doctor/{doctorId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Authorize(Roles = Roles.Doctor)]
    public class DoctorController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _applicationUser;

        public DoctorController(
            IAccountService accountService,
            IMapper mapper,
            IApplicationUser applicationUser)
        {
            _accountService = accountService;
            _mapper = mapper;
            _applicationUser = applicationUser;
        }

        private int UserId => _accountService.GetUserIdByAccountIdAsync(_applicationUser.Id, _applicationUser.Role).Result;

        [HttpPost("patient")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> AddPatientAsync(AccountDto account)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var accountModel = _mapper.Map<AccountDto, AccountModel>(account);

            var result = await _accountService.AddPatientAsync(accountModel, UserId);

            if (result != ResultCode.Success)
            {
                return Conflict((int)result);
            }
            return Ok();
        }

        [HttpGet("info")]
        public async Task<ActionResult> GetInfoAsync(string clinicId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("info")]
        public async Task<ActionResult> UpdateDoctorInfoAsync()//TODO:ClinicDto
        {
            throw new NotImplementedException();
        }

        [HttpGet("patients")]
        public async Task<ActionResult> GetPatientsAsync(string clinicId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("patients_queue")]
        public async Task<ActionResult> GetPatientsQueueAsync(string clinicId)
        {
            throw new NotImplementedException();
        }
    }
}
